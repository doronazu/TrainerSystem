using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application
{
    public class DogSize
    {
        public byte Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
    }
}