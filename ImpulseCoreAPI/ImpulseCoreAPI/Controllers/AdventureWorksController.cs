using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ImpulseCoreAPI.BAL.IRepository;
using ImpulseCoreAPI.Bridge;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ImpulseCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventureWorksController : Controller
    {
        private readonly IAdventureWorks _AdventureWorks;
        private readonly DbEngine _DbEngine;
        private IHostingEnvironment _hostingEnvironment;
        public AdventureWorksController(IAdventureWorks AdventureWorks,IHostingEnvironment hostingEnvironment,DbEngine DbEngine)
        {
            _AdventureWorks = AdventureWorks;
            _hostingEnvironment = hostingEnvironment;
            _DbEngine = DbEngine;
        }
        

        [HttpGet,Route("GetDimAccount")]
        public IActionResult GetDimAccount()
        {
            List<DimAccountModal> DimAccountList = new List<DimAccountModal>();
            DimAccountList = _AdventureWorks.GetDimAccount();
            if (DimAccountList.Count > 0)
                return Json(DimAccountList);
            else
                return Ok("Something Went Wrong!!!!");
        }

        [HttpPost,Route("UploadFilesUsingAngular")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadFilesUsingAngular([FromForm] FileInfoRequest FileInfoRequest)
        {
            //string uploads = Path.Combine(_hostingEnvironment.ContentRootPath,"uploads");
            string uploads = Path.Combine("D:\\New folder\\","Uploaded Files");
            try
            {
                if (FileInfoRequest.FileInfo.Length > 0)
                {
                    string stringPath = @"D:\New folder\Uploaded Files\Rohit_PF_Passbook.pdf";
                    string filePath = Path.Combine(uploads,FileInfoRequest.FileInfo.FileName);
                    bool FilesPathExists = System.IO.File.Exists(stringPath);
                    if (FilesPathExists == false)
                    {
                            using (Stream fileStream = new FileStream(filePath,FileMode.Create))
                        {
                        
                                await FileInfoRequest.FileInfo.CopyToAsync(fileStream);
                                string DBFilePath = @filePath;
                                SaveFilePathToDB(DBFilePath);
                                fileStream.Close();
                                fileStream.Dispose();
                        }
                    }else
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return Ok("Success");
        }

        private Response SaveFilePathToDB(string filePath)
        {
            Response ResponseObj = new Response();
            ImpulseCoreAPI.DAL.FilePathString FilePathString = null;
            try
            {
                using (var transaction = _DbEngine.Database.BeginTransaction())
                {
                   FilePathString = new DAL.FilePathString();
                   FilePathString.Id = 1;
                   FilePathString.FilePath = filePath;
                   _DbEngine.FilePathString.Add(FilePathString);
                   _DbEngine.SaveChanges();
                        transaction.Commit();
                        ResponseObj.IsSuccess = true;
                        ResponseObj.Message = "Data Save Succefully...";
                }
            } catch(Exception ex)
            {
                throw ex;
            }
            return ResponseObj;
        }

        [HttpGet,Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile()
        {
            try
            {
                var path = Path.Combine("D:\\","UploadDownloadFile");
                var memory = new MemoryStream();
                using (var stream = new FileStream(path,FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                var contentType = "Application/octet-stream";
                var fileName = Path.GetFileName(path);
                return File(memory,contentType,fileName);
            } catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
