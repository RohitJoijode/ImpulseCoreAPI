using ImpulseCoreAPI.BAL.IRepository;
using ImpulseCoreAPI.Bridge;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImpulseCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAController : Controller
    {
        private readonly DbEngine _DbEngine;
        private readonly IRsaHelperRepo _RsaHelperRepo;
        public RSAController(DbEngine DbEngine,IRsaHelperRepo RsaHelperRepo)
        {
            _DbEngine = DbEngine;
            _RsaHelperRepo = RsaHelperRepo;
        }

        [HttpPost,Route("EncryptApi")]
        public IActionResult EncryptApi(string EncryptRequestModalObj)
        {
            var VendorName = Request.Headers["VendorName"].ToString();
            var VendorApiKey = Request.Headers["VendorApiKey"].ToString();
            var VendorApiToken = Request.Headers["VendorApiToken"].ToString();
            dynamic RequestObject = null, ResponseObject = null, ReturnData = null;
            ImpulseCoreLogModal ImpulseCoreLogModalObj = new ImpulseCoreLogModal();
            List<DimAccountModal> DimAccountList = new List<DimAccountModal>();
            try
            {
                ReturnData = _RsaHelperRepo.Encrypt(EncryptRequestModalObj);
            }
            catch (Exception ex)
            {
                ReturnData = JsonSerializer.Serialize("Something went Wrong !!!");
                ImpulseCoreLogModalObj.IsError = true;
                ImpulseCoreLogModalObj.ErrorMessage = ex.Message;
            }
            finally
            {
                ResponseObject = JsonSerializer.Serialize(DimAccountList);
                RequestObject = JsonSerializer.Serialize(EncryptRequestModalObj);
                var CommonController = new CommonController();
                ImpulseCoreLogModalObj.ActionMethodName = "EncryptApi";
                ImpulseCoreLogModalObj.APIControllerName = "Common";
                ImpulseCoreLogModalObj.VendorName = VendorName;
                ImpulseCoreLogModalObj.VendorApiKey = VendorApiKey;
                ImpulseCoreLogModalObj.Data = ResponseObject;
                ImpulseCoreLogModalObj.RequestParamterData = RequestObject;
                ImpulseCoreLogModalObj.CreatedBy = "Admin";
                CommonController.ImpulseCoreAPITransactionLog(ImpulseCoreLogModalObj);
            }
            return Ok(ReturnData);
        }

        [HttpPost, Route("DecryptApi")]
        public IActionResult DecryptApi(string EncryptRequestModalObj)
        {
            var VendorName = Request.Headers["VendorName"].ToString();
            var VendorApiKey = Request.Headers["VendorApiKey"].ToString();
            var VendorApiToken = Request.Headers["VendorApiToken"].ToString();
            dynamic RequestObject = null, ResponseObject = null, ReturnData = null;
            ImpulseCoreLogModal ImpulseCoreLogModalObj = new ImpulseCoreLogModal();
            List<DimAccountModal> DimAccountList = new List<DimAccountModal>();
            try
            {
                ReturnData = _RsaHelperRepo.Decrypt(EncryptRequestModalObj);
            }
            catch (Exception ex)
            {
                ReturnData = JsonSerializer.Serialize("Something went Wrong !!!");
                ImpulseCoreLogModalObj.IsError = true;
                ImpulseCoreLogModalObj.ErrorMessage = ex.Message;
            }
            finally
            {
                ResponseObject = JsonSerializer.Serialize(DimAccountList);
                RequestObject = JsonSerializer.Serialize(EncryptRequestModalObj);
                var CommonController = new CommonController();
                ImpulseCoreLogModalObj.ActionMethodName = "DecryptApi";
                ImpulseCoreLogModalObj.APIControllerName = "Common";
                ImpulseCoreLogModalObj.VendorName = VendorName;
                ImpulseCoreLogModalObj.VendorApiKey = VendorApiKey;
                ImpulseCoreLogModalObj.Data = ResponseObject;
                ImpulseCoreLogModalObj.RequestParamterData = RequestObject;
                ImpulseCoreLogModalObj.CreatedBy = "Admin";
                CommonController.ImpulseCoreAPITransactionLog(ImpulseCoreLogModalObj);
            }
            return Ok(ReturnData);
        }

    }
}
