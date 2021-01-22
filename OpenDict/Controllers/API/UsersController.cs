using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenDict.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenDict.Models;
namespace OpenDict.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        private readonly Context _context;
        public UsersController(Context context)
        {
            _context = context;
        }

      public ActionResult<IEnumerable<UserModel>> Index()
        {

           return _context.Users.ToList();
        }
    }
}
