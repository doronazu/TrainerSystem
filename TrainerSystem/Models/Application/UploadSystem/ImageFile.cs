using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application.UploadSystem
{
    public class ImageFile
    {
        public List<HttpPostedFileWrapper> Files { get; set; }
    }
}