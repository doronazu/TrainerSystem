using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using TrainerSystem.Models;
using TrainerSystem.Models.Application;
using TrainerSystem.Models.Application.AppSystem;

namespace TrainerSystem.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class DogsSizeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DogsSizeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: DogsSize
        public async Task<ActionResult> Index()
        {
            var sizeList = await _context.DogSizes.ToListAsync();
            return View(sizeList);
        }

        // GET: DogsSize/New
        public ActionResult New()
        {
            return View("SizeForm",new DogSize(){CreateDate = DateTime.Now,Id = 0});
        }

        // GET: DogsSize/Edit/id
        public async Task<ActionResult> Edit(int id)
        {
            var size = await _context.DogSizes.SingleOrDefaultAsync(s => s.Id == id);
            if (size == null) return HttpNotFound();

            return View("SizeForm", size);
        }

        // Post: DogsSize/Save/object
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(DogSize size)
        {
            if (!ModelState.IsValid)
            {
                return View("SizeForm", size);
            }

            if (size.Id == 0)
            {
                var lastId = _context.DogSizes.Max(s => s.Id);
                if (lastId == 0) lastId = 1;
                else lastId++;
                size.Id = lastId;
                _context.DogSizes.Add(size);
                await _context.SaveChangesAsync();
            }
            else
            {
                var sizeInDb = await _context.DogSizes.SingleOrDefaultAsync(s => s.Id == size.Id);
                if (sizeInDb == null) return HttpNotFound();

                Mapper.Map(size, sizeInDb);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // GET: DogsSize/Details/id
        public async Task<ActionResult> Details(int id)
        {
            var size = await _context.DogSizes.SingleOrDefaultAsync(s => s.Id == id);
            if (size == null) return HttpNotFound();

            return View(size);
        }

        // Post: DogsSize/Delete/id
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var size = await _context.DogSizes.SingleOrDefaultAsync(s => s.Id == id);
            if (size == null) return HttpNotFound();

            _context.DogSizes.Remove(size);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}