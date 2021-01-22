using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenDict.Data;
using OpenDict.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDict.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaleStringResourcesController : ControllerBase
    {
        private readonly Context _context;

        public LocaleStringResourcesController (Context context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocaleStringResourcesModel >>> GetLocaleStringResource()
        {
            return await _context.LocaleStringResources.ToListAsync();
        }
        [Route("Locale")]
        [HttpGet]
        public  LocaleStringResourcesModel Locale(string localeString, int languageId)
        {
            var localeStringObject =   _context.LocaleStringResources.Where(q => q.LanguageId == languageId && q.LocaleString == localeString).FirstOrDefault();
            return  localeStringObject;
        }
    }
}
