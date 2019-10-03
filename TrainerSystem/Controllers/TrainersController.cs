using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TrainerSystem.Models;
using TrainerSystem.Models.Application.AppSystem;

namespace TrainerSystem.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class TrainersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Trainers
        public ActionResult Index()
        {

            return View();
        }
        
    }
}