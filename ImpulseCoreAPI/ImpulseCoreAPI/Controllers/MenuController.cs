using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpulseCoreAPI.Bridge;
using ImpulseCoreAPI.BAL.IRepository;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text;
using ImpulseCoreAPI.Enums;

namespace ImpulseCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly IRsaHelperRepo _RsaHelperRepo;
        private readonly IMenuRepo _MenuRepo;
        private readonly DbEngine _DbEngine;
        private readonly IConfiguration config;
        public MenuController(IRsaHelperRepo RsaHelperRepo,IMenuRepo MenuRepo,DbEngine DbEngine, IConfiguration _config)
        {
            _RsaHelperRepo = RsaHelperRepo;
            _MenuRepo = MenuRepo;
            _DbEngine = DbEngine;
            config = _config;
        }

        [HttpPost,Route("GetMenuByUserId")]
        public IActionResult GetMenuByUserId(UserLogInRequest UserLogInRequest)
        {
            UserLogInRequest.UserId = _RsaHelperRepo.Decrypt(UserLogInRequest.UserId);
            List<getMenu> GetMenuList = new List<getMenu>();
            try
            {
                GetMenuList = _MenuRepo.GetMenuByUserId(UserLogInRequest);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return Ok(GetMenuList);
        }

        [HttpPost,Route("GetSubMenuByUserIdAndMenuId")]
        public IActionResult GetSubMenuByUserIdAndMenuId(UserLogInRequest UserLogInRequest)
        {
            UserLogInRequest.UserId = _RsaHelperRepo.Decrypt(UserLogInRequest.UserId);
            UserLogInRequest.MenuId = _RsaHelperRepo.Decrypt(UserLogInRequest.MenuId);
            List<GetSubMenu> GetSubMenuList = new List<GetSubMenu>();
            try
            {
                GetSubMenuList = _MenuRepo.GetSubMenuByUserIdAndMenuId(UserLogInRequest);

                for(int i = 0; i < GetSubMenuList.Count();i++)
                {
                    GetSubMenuList[i].SubMenuName = GetSubMenuList[i].SubMenuName.Replace("\r\n","");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(GetSubMenuList);
        }
    }
}
