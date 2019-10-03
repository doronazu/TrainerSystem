using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using TrainerSystem.Models;
using TrainerSystem.Models.Application;
using TrainerSystem.Models.Application.AppSystem;
using TrainerSystem.ViewModels;

namespace TrainerSystem.Controllers
{
    [Authorize(Roles = RoleName.Admin + "," + RoleName.Manager)]
    public class PackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PackagesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private async Task<ApplicationUser>  GetUser()
        {
            var uid = User.Identity.GetUserId();
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == uid);
        }
        // GET: Packages
        public async Task<ActionResult> Index()
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var packages = await _context.Packages.Where(t=>t.TrainerId == user.TrainerId).ToListAsync();

            return View(packages);
        }

        // GET: Packages/Details/id
        public async Task<ActionResult> Details(int id)
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var package = await _context.Packages.SingleOrDefaultAsync(p => p.Id == id && p.TrainerId == user.TrainerId);
            if (package == null) return HttpNotFound();

            var packageViewModel = Mapper.Map<Package, PackageViewModel>(package);
            return View(packageViewModel);
        }
        // GET: Packages
        public async Task<ActionResult> New()
        {
            var user = await GetUser();
            return View("PackageForm",new PackageViewModel(){CreateDate = DateTime.Now,TrainerId = user.TrainerId});
        }

        // GET: Packages
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var package = await _context.Packages.SingleOrDefaultAsync(p => p.Id == id && p.TrainerId == user.TrainerId);
            if (package == null) return HttpNotFound();

            var packageViewModel = Mapper.Map<Package, PackageViewModel>(package);

            return View("PackageForm", packageViewModel);
        }

        // Post: Packages/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(PackageViewModel package)
        {
            if (!ModelState.IsValid)
            {
                return View("PackageForm", package);
            }


            var user = await GetUser();
            if (user == null) return HttpNotFound();

            if (package.Id == 0)
            {
                package.TrainerId = user.TrainerId;
                var p = Mapper.Map<PackageViewModel, Package>(package);

                _context.Packages.Add(p);
                await _context.SaveChangesAsync();
            }
            else
            {
                var packageInDb = await _context.Packages.SingleOrDefaultAsync(p => p.Id == package.Id && p.TrainerId == user.TrainerId);
                if (packageInDb == null) return HttpNotFound();

                Mapper.Map(package, packageInDb);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index","Packages");
        }
        // Delete: Packages/Delete/id
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var package = await _context.Packages.SingleOrDefaultAsync(p => p.Id == id && p.TrainerId == user.TrainerId);
            if (package == null) return HttpNotFound();

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","Packages");
        }


    }
}