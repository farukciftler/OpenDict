using Microsoft.AspNetCore.Mvc;
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
            /*List<LocaleStringResourcesModel> localeStringResources = new List<LocaleStringResourcesModel>();
            localeStringResources = httpHelper.GetApiEndpoint<List<LocaleStringResourcesModel>>("/localestringresources");
            return View(localeStringResources);*/
            return View();
        }

    }
}
