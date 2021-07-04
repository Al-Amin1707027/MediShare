using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;


namespace mainServer.Controllers.Dashboard.UserDashboard
{
    public class fileupload : Controller
    {


        public IActionResult Index()
        {
            return View("~/Views/fileupload.cshtml");
        }



        public async Task<bool> UploadFile(IFormFile file)
        {
            bool isSaveSuccess = false;
            string fileName;

            try{
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension;

                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");

                if(!Directory.Exists(pathBuilt)){
                    Directory.CreateDirectory(pathBuilt);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images",fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                
                Console.WriteLine("file is uploading.......");
                
                isSaveSuccess = true;
            }
            catch (Exception e)
            {
                // Console.Writeline(e);
            }

            return isSaveSuccess;
        }
    }
}