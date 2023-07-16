using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI.Bridge
{
    public class FileInfoRequest
    {
        public IFormFile FileInfo { get; set; }
        public string FilePath { get; set; }
        public string FileDirectory { get; set; }
    }

    public class UserLogInRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
