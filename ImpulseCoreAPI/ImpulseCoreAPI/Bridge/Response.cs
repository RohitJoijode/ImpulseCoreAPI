using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI.Bridge
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ResponseData<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ResponseData<T> Data {get;set;}
    }

    public class UserLogInResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string UserEmailId { get; set; }
        public string UserMobileNo { get; set; }
        public string UserId { get; set; }

    }


}
