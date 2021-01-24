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

        public IActionResult Login(string username, string password)
        {

            UserModel login = new UserModel
            {
                Username = username,
                Password = password
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
        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var user = _context.Users.Where(s => (s.Username == userInfo.Username)).FirstOrDefault();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userLevel = _context.UserGroup.Where(s => (s.Level == user.UserGroupLevel)).FirstOrDefault();
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
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);



            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<UserModel>> Register(UserModel userModel)
        {
            userModel.RegisterDate = DateTime.Now;
            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetUserModel", new { Id = userModel.Id }, userModel);
        }

    }
}
