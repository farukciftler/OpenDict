using Microsoft.AspNetCore.Mvc;


namespace OpenDict.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaleStringResourcesController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Merhaba";
        }
    }
}
