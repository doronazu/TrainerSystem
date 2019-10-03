using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using TrainerSystem.Models;
using TrainerSystem.Models.Application;
using TrainerSystem.Models.Application.AppSystem;

namespace TrainerSystem.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class DogsRaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DogsRaceController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Race
        public async Task<ActionResult> Index()
        {
            var raceList = await _context.Races.ToListAsync();
            return View(raceList);
        }

        // GET: Race/New
        public ActionResult New()
        {
            return View("RaceForm", new Race(){CreateDate = DateTime.Now});
        }

        // GET: Race/Edit/id
        public async Task<ActionResult> Edit(int id)
        {
            var race = await _context.Races.SingleOrDefaultAsync(r=>r.Id == id);
            if (race == null) return HttpNotFound();

            return View("RaceForm", race);
        }

        // Post: Race/Save/object
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View("RaceForm", race);
            }
            if (race.Id == 0)
            {
                _context.Races.Add(race);
                await _context.SaveChangesAsync();
            }
            else
            {
                var raceInDb = await _context.Races.SingleOrDefaultAsync(r => r.Id == race.Id);
                if (raceInDb == null) return HttpNotFound();

                Mapper.Map(race, raceInDb);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // GET: Race/Details/id
        public async Task<ActionResult> Details(int id)
        {
            var race = await _context.Races.SingleOrDefaultAsync(r=>r.Id == id);
            if (race == null) return HttpNotFound();

            return View(race);
        }

        // Post: Race/Delete/id
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var race = await _context.Races.SingleOrDefaultAsync(r=>r.Id == id);
            if (race == null) return HttpNotFound();

            _context.Races.Remove(race);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}