using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using TrainerSystem.Models;
using TrainerSystem.Models.Application.AppSystem;
using TrainerSystem.ViewModels;

namespace TrainerSystem.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ManageSystemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageSystemController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ManageSystem
        public ActionResult Index()
        {
            return View();
        }
        // GET: Users
        public ActionResult Users()
        {
            var roles = _context.Roles.ToList();
            var role = "אין";


            var users = _context.Users.ToList();
            var trainers = _context.Trainers.ToList();
            var viewModelList = new List<UserToViewModel>();
            foreach (var user in users)
            {
                var userRole = user.Roles.FirstOrDefault();

                if (userRole != null)
                {
                    var roleInDb = roles.SingleOrDefault(r => r.Id == userRole.RoleId);
                    if (roleInDb != null)
                    {
                        switch (roleInDb.Name)
                        {
                            case "Admin":
                                role = "מנהל";
                                break;
                            case "Manager":
                                role = "משתמש רשום";
                                break;
                        }
                    }
                };

                var trainer = trainers.SingleOrDefault(t => t.Id == user.TrainerId);
                if (trainer == null) continue;

                var uvm = new UserToViewModel()
                {
                    User = user,
                    Role = role,
                    Trainer = trainer
                };
                viewModelList.Add(uvm);

            }
            var viewModel = new UsersViewModel()
            {
                Users = viewModelList,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(viewModel);
        }


        // GET: ManageSystem
        public ActionResult Dogs()
        {
            return View();
        }
    }
}