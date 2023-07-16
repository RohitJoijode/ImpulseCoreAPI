using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpulseCoreAPI.Bridge;
using ImpulseCoreAPI.BAL.IRepository;

namespace ImpulseCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : Controller
    {
        private readonly IRsaHelperRepo _RsaHelperRepo;
        public LogInController(IRsaHelperRepo RsaHelperRepo)
        {
            _RsaHelperRepo = RsaHelperRepo;
        }

        [HttpPost,Route("UserLogIn")]
        public ResponseData<UserLogInResponse> UserLogIn(UserLogInRequest UserLogInRequestObj)
        {
            ResponseData<UserLogInResponse> ResponseDataObj = new ResponseData<UserLogInResponse>();
            UserLogInRequestObj.UserName = _RsaHelperRepo.Decrypt(UserLogInRequestObj.UserName);
            UserLogInRequestObj.Password = _RsaHelperRepo.Decrypt(UserLogInRequestObj.Password);
            ResponseDataObj.IsSuccess = true;
            ResponseDataObj.Message = "Tasks Successfull...";
            return ResponseDataObj;
        }
    }
}
