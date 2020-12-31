using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenDict.Data;

namespace OpenDict.Controllers
{
    [Route("[controller]")]
    public class LanguageController : Controller
    {
        private readonly Context _context;

        public LanguageController(Context context)
        {
            _context = context;
        }

        // GET: Language
        public async Task<IActionResult> Index()
        {
            return View(await _context.Language.ToListAsync());
        }

  
    }
}
