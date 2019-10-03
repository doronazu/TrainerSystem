using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application
{
    public class Shop
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public bool Visible { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfileImage { get; set; }
        public string SubjectImage { get; set; }
    }
}