using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainerSystem.Models;
using TrainerSystem.Models.Application;

namespace TrainerSystem.ViewModels
{
    public class UsersViewModel
    {
        public List<UserToViewModel> Users { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
    }
}