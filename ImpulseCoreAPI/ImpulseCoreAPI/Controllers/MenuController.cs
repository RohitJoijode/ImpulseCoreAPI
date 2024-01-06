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

        [HttpPost,Route("GetUsersList")]
        public IActionResult GetUsersList(UserLogInRequest UserLogInRequest)
        {
            UserLogInRequest.UserId = _RsaHelperRepo.Decrypt(UserLogInRequest.UserId);
            List<GetUsers> GetUsersList = new List<GetUsers>();
            try
            {
                GetUsersList = _MenuRepo.GetUsersList(UserLogInRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(GetUsersList);
        }

        [HttpPost,Route("SaveupdateUserList")]
        public IActionResult SaveupdateUserList(UserRequest UserRequest)
        {
            UserRequest.UserId = _RsaHelperRepo.Decrypt(UserRequest.UserId);
            UserRequest.Id = _RsaHelperRepo.Decrypt(UserRequest.Id);
            UserRequest.Name = _RsaHelperRepo.Decrypt(UserRequest.Name);
            UserRequest.Address1 = _RsaHelperRepo.Decrypt(UserRequest.Address1);
            UserRequest.Address2 = _RsaHelperRepo.Decrypt(UserRequest.Address2);
            UserRequest.Address3 = _RsaHelperRepo.Decrypt(UserRequest.Address3);
            UserRequest.EmailId = _RsaHelperRepo.Decrypt(UserRequest.EmailId);
            UserRequest.Password = _RsaHelperRepo.Decrypt(UserRequest.Password);
            UserRequest.MobileNo = _RsaHelperRepo.Decrypt(UserRequest.MobileNo);
            UserRequest.IsActive = _RsaHelperRepo.Decrypt(UserRequest.IsActive);
            UserRequest.PAN = _RsaHelperRepo.Decrypt(UserRequest.PAN);
            UserRequest.TYPE = _RsaHelperRepo.Decrypt(UserRequest.TYPE);
            
            List<dbresponse> dbresponse = new List<dbresponse>();
            try
            {
                dbresponse = _MenuRepo.SaveupdateUserList(UserRequest);
            }
            catch (Exception ex)
            {
                dbresponse[0].status = false;
                dbresponse[0].message = "Something went wrong !!!";
                throw ex;
            }
                return Ok(dbresponse);
        }

        [HttpPost, Route("GetUserEditData")]
        public IActionResult GetUserEditData(UserRequest UserRequest)
        {
            UserRequest.UserId = _RsaHelperRepo.Decrypt(UserRequest.UserId);
            UserRequest.Id = _RsaHelperRepo.Decrypt(UserRequest.Id);
            GetUsers GetUsers = new GetUsers();
            try
            {
                GetUsers = _MenuRepo.GetUserEditData(UserRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(GetUsers);
        }

        [HttpPost,Route("getdemoUserList")]
        public IActionResult getdemoUserList(UserRequest UserRequest)
        {
            List<GetUsers> GetUsersList = new List<GetUsers>();
            try
            {
                UserRequest.search = _RsaHelperRepo.Decrypt(UserRequest.search);
                UserRequest.Start = _RsaHelperRepo.Decrypt(UserRequest.Start);
                UserRequest.Take = _RsaHelperRepo.Decrypt(UserRequest.Take);
                UserRequest.orderBy = _RsaHelperRepo.Decrypt(UserRequest.orderBy);
                GetUsersList = _MenuRepo.getdemoUserList(UserRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(GetUsersList);
        }
    }
}
