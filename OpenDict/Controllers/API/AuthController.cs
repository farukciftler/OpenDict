using Microsoft.Extensions.Configuration;
using OpenDict.Data;
using OpenDict.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace OpenDict.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly Context _context;
        public AuthController(IConfiguration config, Context context)
        {
            _config = config;
            _context = context;
        }
        [Route("Login")]
        [HttpGet]
        public IActionResult Login(string username, string password)
        {

            UserModel login = new UserModel
            {
                Username = username,
                Password = HashPasswordUsingMD5(password)
            };

            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }
            return response;
        }

        [Route("GetUser")]
        [HttpPost]
        public UserModel GetUser(UserModel userModel)
        {
            userModel.Password = HashPasswordUsingMD5(userModel.Password);
            userModel = _context.Users.Where(q => q.Username == userModel.Username && q.Password == userModel.Password).FirstOrDefault();
            return userModel;
        }
        private UserModel AuthenticateUser(UserModel login)
        {
            var UserInfo = _context.Users.Where(s => (s.Username == login.Username))
            .FirstOrDefault();

            UserModel user = null;
            if (login.Username == UserInfo.Username && login.Password == UserInfo.Password)
            {
                user = UserInfo;
            }
            return user;
        }
        
        private IActionResult GenerateJSONWebToken(UserModel userInfo)


        {
            var user = _context.Users.Where(s => (s.Username == userInfo.Username)).FirstOrDefault();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //var keySize = credentials.Key.KeySize;


            var userLevel = 
                _context
                .UserGroup
                .Where(s => (s.Level == user.UserGroupLevel && s.LanguageId == 1))
                .FirstOrDefault();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userLevel.UserGroup)
            };


            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120)
                //signingCredentials: credentials
                );



            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
            return Unauthorized();
        }
        private string generateJwtToken(UserModel userModel)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userModel.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<UserModel>> Register(UserModel userModel)
        {
            userModel.RegisterDate = DateTime.Now;
            userModel.Password = HashPasswordUsingMD5(userModel.Password);
            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUserModel", new { userModel.Id }, userModel);
        }
        public static string HashPasswordUsingMD5(string password)
        {
            using var md5 = MD5.Create();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            byte[] hash = md5.ComputeHash(passwordBytes);

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
                stringBuilder.Append(hash[i].ToString("X2"));

            return stringBuilder.ToString();
        }

    }
}
