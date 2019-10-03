using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application
{
    public class Package
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public DateTime CreateDate { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public short Discount { get; set; }
        public string Image { get; set; }
    }
}