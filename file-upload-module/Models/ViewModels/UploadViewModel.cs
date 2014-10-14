using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace file_upload_module.Models.ViewModels
{
    public class UploadViewModel
    {
        [Required(ErrorMessage = "Please select a file")]
        public HttpPostedFileBase File { get; set; }
    }
}