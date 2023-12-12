using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpulseCoreAPI.BAL.IRepository;
using ImpulseCoreAPI.Bridge;

namespace ImpulseCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : Microsoft.AspNetCore.Mvc.Controller
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHome _Home;
        
        public WeatherForecastController(ILogger<WeatherForecastController> logger,IHome Home)
        {
            _logger = logger;
            _Home = Home;
        }

        [HttpGet,Route("GetAllMember")]
        public IActionResult GetAllMember()
        {
            try
            {
                List<getMenu> MemberList = new List<getMenu>();
                MemberList = _Home.GetAllMember();
                if (MemberList.Count > 0)
                    return Ok(MemberList);
                else
                    return Ok("Something Went Wrong!!!!");
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet,Route("GetMember")]
        public IActionResult GetMember(int Id)
        {
            try
            {
                List<getMenu> MemberList = new List<getMenu>();
                MemberList = _Home.GetMember(Id);
                if (MemberList != null)
                    return Ok(MemberList);
                else
                    return Ok("Something Went Wrong!!!!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost,Route("SaveMembersDetails")]
        public IActionResult SaveMembersDetails(Member MemberObj)
        {
            try
            {
                Response ResponseObj = new Response();
                ResponseObj = _Home.SaveMembersDetails(MemberObj);
                if (ResponseObj != null)
                    return Ok(ResponseObj);
                else
                    return Ok("Something Went Wrong!!!!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost,Route("SP_DemoMultipleTableExcution")]
        public IActionResult SP_DemoMultipleTableExcution()
        {
            try
            {
                List<Employee> ResponseObj = new List<Employee>();
                ResponseObj = _Home.SP_DemoMultipleTableExcution();
                if (ResponseObj != null)
                    return Ok(ResponseObj);
                else
                    return Ok("Something Went Wrong!!!!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
