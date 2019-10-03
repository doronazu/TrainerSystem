using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application
{
    public class Race
    {
        public short Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
    }
}