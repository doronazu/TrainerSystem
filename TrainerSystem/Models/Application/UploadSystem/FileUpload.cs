using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application.UploadSystem
{
    public class FileUpload
    {
        public string Name { get; set; }
        public HttpPostedFileWrapper File { get; set; }
    }
}