using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainerSystem.Models;
using TrainerSystem.Models.Application;

namespace TrainerSystem.ViewModels
{
    public class UserToViewModel
    {
        public ApplicationUser User { get; set; }
        public string Role { get; set; }
        public Trainer Trainer { get; set; }
    }
}