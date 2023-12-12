using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpulseCoreAPI.Bridge;
using ImpulseCoreAPI.BAL.IRepository;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ImpulseCoreAPI.Enums;

namespace ImpulseCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : Controller
    {

        public static string SecretKey { get; set; }
        public static int TokenDuration { get; set; }

        private readonly IRsaHelperRepo _RsaHelperRepo;
        private readonly DbEngine _DbEngine;
        private readonly IConfiguration config;
        public LogInController(IRsaHelperRepo RsaHelperRepo,DbEngine DbEngine,IConfiguration _config) 
        {   
            _RsaHelperRepo = RsaHelperRepo;
            _DbEngine = DbEngine;
            config = _config;
        }
        [HttpPost,Route("UserLogIn")]
        public IActionResult UserLogIn(UserLogInRequest UserLogInRequestObj)
        {
            ResponseData<string> ResponseDataObj = new ResponseData<string>();
            try
            {
                string Data = "";
                UserLogInRequestObj.UserName = _RsaHelperRepo.Decrypt(UserLogInRequestObj.UserName);
                UserLogInRequestObj.Password = _RsaHelperRepo.Decrypt(UserLogInRequestObj.Password);
                var UserLogInObject = _DbEngine.Users.Where(x => x.EmailId == UserLogInRequestObj.UserName 
                                                                    && x.Password == UserLogInRequestObj.Password 
                                                                    && x.IsActive == true
                                                                ).FirstOrDefault();

                if(UserLogInObject != null)
                {
                      string key =  config.GetSection("JWTConfig").GetSection("key").Value;
                      string TokenDuration = config.GetSection("JWTConfig").GetSection("Duration").Value;
                      ResponseDataObj.Token = GenerateToken(UserLogInObject.Id.ToString(),UserLogInObject.Name.ToString(),UserLogInObject.EmailId.ToString(),UserLogInObject.MobileNo.ToString(),UserLogInObject.TYPE.ToString(),key,TokenDuration);
                      ResponseDataObj.Message = "LogIn Successfully !!!";
                      ResponseDataObj.IsSuccess = true;
                } else
                {
                    ResponseDataObj.Message = "Your UserName and Password Invalid !!!";
                    ResponseDataObj.IsSuccess = false;
                }
                return Ok(ResponseDataObj);
            }
            catch (Exception ex)
            {

            }
            return BadRequest("Failure !!!");
        }
        public static string GenerateToken(string Id,string name,string email,string mobile,string role,string keyd,string TokenDuration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyd));
            var Signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var payload = new[]
            {
                new Claim("Userid",Id),
                new Claim("CompanyName",name),
                new Claim("CompanyEmail",email),
                new Claim("mobile",mobile),
                new Claim("role",role)
            };

            var jwttoken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(int.Parse(TokenDuration)),
                signingCredentials: Signature
                );

            return new JwtSecurityTokenHandler().WriteToken(jwttoken);
        }

    }
}
