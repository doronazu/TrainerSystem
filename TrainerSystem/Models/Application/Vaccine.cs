using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application
{
    public class Vaccine
    {
        public int Id { get; set; }
        public int DogId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}