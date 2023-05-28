using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ImpulseCoreAPI.BAL.IRepository;
using ImpulseCoreAPI.Bridge;

namespace ImpulseCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventureWorksController : Controller
    {
        private readonly IAdventureWorks _AdventureWorks;
        public AdventureWorksController(IAdventureWorks AdventureWorks)
        {
            _AdventureWorks = AdventureWorks;
        }

        [HttpGet,Route("GetDimAccount")]
        public IActionResult GetDimAccount()
        {
            List<DimAccountModal> DimAccountList = new List<DimAccountModal>();
            //DimAccountList = _AdventureWorks.GetDimAccount();

            //if (DimAccountList.Count > 0)
            //    return Json(DimAccountList);
            //else
            //    return Ok("Something Went Wrong!!!!");
            return Json(DimAccountList);
        }
    }
}
