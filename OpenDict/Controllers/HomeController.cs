using Microsoft.AspNetCore.Mvc;

namespace OpenDict.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
