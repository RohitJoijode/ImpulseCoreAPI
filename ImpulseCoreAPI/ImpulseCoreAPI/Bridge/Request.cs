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
        public string UserId { get; set; }
        public string MenuId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string token { get; set; }
    }

    public class UserRequest
    {

        public string Id           {get;set;}
        public string Name         {get;set;}
        public string Address1     {get;set;}
        public string Address2     {get;set;}
        public string Address3     {get;set;}
        public string EmailId      {get;set;}
        public string Password     {get;set;}
        public string MobileNo     {get;set;}
        public string PAN          {get;set;}
        public string TYPE         {get;set;}
        public string IsActive     {get;set;}
        public string CreatedBy    {get;set;}
        public string CreatedOn    {get;set;}
        public string Mode { get; set; }
        public string UserId { get; set; }
        public string Start { get; set; }
        public string Take { get; set; }
        public string orderBy { get; set; }
        public string search { get; set; }
    }
}
