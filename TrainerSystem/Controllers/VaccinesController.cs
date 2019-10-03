using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using TrainerSystem.Models;
using TrainerSystem.Models.Application;

namespace TrainerSystem.Controllers
{
    public class VaccinesController : Controller
    {
        private ApplicationDbContext _context;

        private ApplicationUser GetUser()
        {
            var uid = User.Identity.GetUserId();
            return _context.Users.SingleOrDefault(u => u.Id == uid);
        }
        private Trainer GetTrainer()
        {
            var user = GetUser();
            if (user == null) return null;
            var trainer = _context.Trainers
                .Include(t=>t.Customers)
                .Include(t=>t.Shop)
                .Include(t=>t.Packages)
                .SingleOrDefault(t=>t.Id == user.TrainerId);
            if (trainer == null) return null;
            var dogList = _context.Dogs
                .Include(d => d.Vaccines)
                .Include(d => d.Race)
                .Include(d => d.DogSize).ToList();
            foreach (var customer in trainer.Customers)
            {
                customer.DogList = dogList.Where(d => d.CustomerId == customer.Id).ToList();
            }
            return trainer;
        }

        public VaccinesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Vaccines
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vaccines/New/dogId
        public ActionResult New(int id)
        {
            return View("VaccineForm",new Vaccine(){CreateDate = DateTime.Now,DogId = id});
        }

        // Post: Vaccines/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Vaccine vaccine)
        {
            if (!ModelState.IsValid)
            {
                return View("VaccineForm", vaccine);
            }
            var trainer = GetTrainer();
            if (trainer == null) return HttpNotFound();

            var dog = trainer.Customers.Select(c => c.DogList.SingleOrDefault(d => d.Id == vaccine.DogId)).FirstOrDefault(d => d != null);
            if (dog == null) return HttpNotFound();

            if (vaccine.Id == 0)
            {
                dog.Vaccines.Add(vaccine);
                _context.SaveChanges();
            }
            else
            {
                var vaccineInDb = dog.Vaccines.SingleOrDefault(v => v.Id == vaccine.Id);
                if (vaccineInDb == null) return HttpNotFound();
                Mapper.Map(vaccine, vaccineInDb);
                _context.SaveChanges();
            }
            return RedirectToAction("Dog", new {@id = vaccine.DogId});
        }

        // GET: Vaccines/Edit/id
        public ActionResult Edit(int id)
        {
            var trainer = GetTrainer();
            if (trainer == null) return HttpNotFound();

            var vaccineInDb = trainer.Customers.Select(c => c.DogList.Select(d=>d.Vaccines.SingleOrDefault(v=>v.Id == id)).FirstOrDefault(d => d != null)).FirstOrDefault(v => v != null);
            if (vaccineInDb == null) return HttpNotFound();

            return View("VaccineForm",vaccineInDb);
        }

        // GET: Vaccines/Dog/id
        public ActionResult Dog(int id)
        {
            var trainer = GetTrainer();
            if (trainer == null) return HttpNotFound();

            var dog = trainer.Customers.Select(c => c.DogList.SingleOrDefault(d => d.Id == id)).FirstOrDefault(d=>d != null);
            
            return View(dog);
        }

        // Post: Vaccines/Delete/id
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var trainer = GetTrainer();
            if (trainer == null) return HttpNotFound();

            var vaccineInDb = trainer.Customers.Select(c => c.DogList.Select(d => d.Vaccines.SingleOrDefault(v => v.Id == id)).FirstOrDefault(d => d != null)).FirstOrDefault(v => v != null);
            if (vaccineInDb == null) return HttpNotFound();
            
            var dog = trainer.Customers.Select(c => c.DogList.SingleOrDefault(d => d.Id == vaccineInDb.DogId)).FirstOrDefault(v => v != null);
            if (dog == null) return HttpNotFound();

            dog.Vaccines.Remove(vaccineInDb);
            _context.Vaccines.Remove(vaccineInDb);
            _context.SaveChanges();

            return RedirectToAction("Dog", new { @dogId = dog.Id });
        }
    }
}