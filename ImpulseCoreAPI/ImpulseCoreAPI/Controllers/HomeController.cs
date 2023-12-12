using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpPost,Route("SaveMembersDetails")]
        public IActionResult Index()
        {
            return Ok("Something Went Wrong!!!!");
        }

    }
}
