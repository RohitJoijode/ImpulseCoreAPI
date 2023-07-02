using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulseCoreAPI.Bridge
{
    public class ImpulseCoreLogModal
    {
        public string APIControllerName { get; set; }
        public string ActionMethodName { get; set; }
        public string IP { get; set; }
        public string RequestParamterData { get; set; }
        public string VendorName { get; set; }
        public string VendorApiKey { get; set; }
        public bool? IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string Data { get; set; }
        public string EncryptRequestParamterData { get; set; }
        public DateTime CreatedDate  { get; set; }
        public string CreatedBy { get; set; }
    }
}
