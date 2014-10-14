using file_upload_module.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace file_upload_module.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UploadViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                HttpPostedFileBase uploadFile = model.File;

                try
                {
                    if (uploadFile.ContentLength > 0)
                    {
                        // Create save path and put the uploaded file in that location
                        var fileName = Path.GetFileName(uploadFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/App_Data/File_Uploads"), fileName);
                        uploadFile.SaveAs(path);
                    }

                    ViewBag.Message = "File Upload Successful";
                    return View();
                }
                catch
                {
                    ViewBag.Message = "File Upload Failed";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Error Creating Upload Model";
                return View();
            }
        }
    }
}