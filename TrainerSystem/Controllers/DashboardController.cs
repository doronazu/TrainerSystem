using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TrainerSystem.Models;
using TrainerSystem.Models.Application.AppSystem;

namespace TrainerSystem.Controllers
{
    [Authorize(Roles = RoleName.Admin + "," + RoleName.Manager)]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            var uid = User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(u => u.Id == uid);

            if (user == null) return HttpNotFound();
            var trainer = _context.Trainers.SingleOrDefault(t => t.Id == user.TrainerId);

            return View(trainer);
        }
    }
}