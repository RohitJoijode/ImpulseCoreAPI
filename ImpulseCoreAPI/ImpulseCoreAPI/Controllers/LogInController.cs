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

                var UserLogInObject = _DbEngine.Users.Where(x => x.EmailId == UserLogInRequestObj.UserName && x.Password == UserLogInRequestObj.Password && x.IsActive == true).FirstOrDefault();

                if(UserLogInObject == null)
                {
                    //string Id,string firstName,string lastName,string email,string mobile,string gender

                      string key =  config.GetSection("JWTConfig").GetSection("key").Value;
                      string TokenDuration = config.GetSection("JWTConfig").GetSection("Duration").Value;
                      ResponseDataObj.Message = GenerateToken("09", "rohit", "joijode", "rohitjoijode122@gmail.com", "8108781487", "male",key,TokenDuration);
                      ResponseDataObj.IsSuccess = true;
                }
                return Ok(ResponseDataObj);
            }
            catch (Exception ex)
            {

            }
            return BadRequest("Failure !!!");
        }

        public static string GenerateToken(string Id, string firstName, string lastName, string email, string mobile, string gender,string keyd,string TokenDuration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyd));
            var Signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var payload = new[]
            {
                new Claim("id",Id),
                new Claim("firstName",firstName),
                new Claim("lastName",lastName),
                new Claim("email",email),
                new Claim("mobile",mobile),
                new Claim("gender",gender)
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
