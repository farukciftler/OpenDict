﻿using Microsoft.AspNetCore.Mvc;
using OpenDict.Helpers;
using OpenDict.Models;
using System.Collections.Generic;

namespace OpenDict.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly HttpHelper httpHelper;
        public HomeController(HttpHelper httpHelper)
        {
            this.httpHelper = httpHelper;
        }
        // GET: HomeController
        public ActionResult Index()
        {
     
            return View();
        }
        
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [Route("Forgot")]

        public ActionResult ForgotPass()
        {
            return View();
        }
    }
}
