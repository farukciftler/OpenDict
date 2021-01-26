using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OpenDict.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenDict.Models;
using Microsoft.AspNetCore.Http;

namespace OpenDict.Controllers
{
    public class LoginController : Controller
    {
        const string SessionName = "_username";
        const string SessionPass = "_token";
        const string SessionLevel = "_level";
        const string SessionId = "_id";
        private readonly HttpHelper _httpHelper;
        private readonly LocalizationHelper _localizationHelper;
        public LoginController( HttpHelper httpHelper, LocalizationHelper localizationHelper)
        {

            _httpHelper = httpHelper;
            _localizationHelper = localizationHelper;

        }
        [HttpPost]
        public IActionResult Index(string username, string password)
        {

            var token = _httpHelper.GetToken(username, password);
            if (token != null)
            {

                UserModel userModel = new UserModel
                {
                    Password = password,
                    Username = username
                };
                var user = _httpHelper.PostMethod<UserModel>(userModel, "/api/auth/getuser");
                HttpContext.Session.SetInt32(SessionLevel, user.UserGroupLevel);
                HttpContext.Session.SetInt32(SessionId, user.Id);
                HttpContext.Session.SetString(SessionName, username);
                HttpContext.Session.SetString(SessionPass, token);
                //Require last login update
                ViewBag.Message = _localizationHelper.T("Login.SuccessfullyLogin");
            }
            else
            {
                ViewBag.Message = _localizationHelper.T("Login.UnsuccessfullyLogin.UsernameOrPassword");
                return View();
            }

            ViewBag.Name = HttpContext.Session.GetString("_username");
            ViewBag.Pass = HttpContext.Session.GetString("_password");
            return View("../Home/Index");

        }


        [HttpPost]
        public UserModel Register(string username, string password, string email)
        {
            UserModel newUser = new UserModel
            {
                Username = username,
                Password = password,
                Email = email
            };
            return _httpHelper.PostMethod<UserModel>(newUser, "/api/auth/register");
        }




    }
}
