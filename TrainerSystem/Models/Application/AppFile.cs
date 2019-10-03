using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainerSystem.Models.Application.AppSystem;

namespace TrainerSystem.Models.Application
{
    public class AppFile
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }

        public string Type { get; set; }
        public string FilePath { get; set; }
        public DateTime DateTimeAdded { get; set; }
    }
}