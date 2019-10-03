using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using TrainerSystem.Models;
using TrainerSystem.Models.Application;
using TrainerSystem.Models.Application.AppSystem;
using TrainerSystem.ViewModels;

namespace TrainerSystem.Controllers
{
    public class DogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DogsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private async Task<ApplicationUser> GetUser()
        {
            var uid = User.Identity.GetUserId();
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == uid);
        }

        // GET: Dogs
        public async Task<ActionResult> Index()
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var trainer = await _context.Trainers.Include(t=>t.Customers).SingleOrDefaultAsync(t=>t.Id == user.TrainerId);
            if (trainer == null) return HttpNotFound();

            var dogsInDb = _context.Dogs
              .Include(d => d.Vaccines)
              .Include(d => d.Race)
              .Include(d => d.DogSize).ToList();

            foreach (var customer in trainer.Customers)
            {
                customer.DogList = dogsInDb.Where(d => d.CustomerId == customer.Id).ToList();
            }

            var doglist = trainer.Customers.SelectMany(c => c.DogList.Select(Mapper.Map<Dog, DogViewModel>));
            
            var viewModel = new DogsViewModel()
            {
                Dogs = doglist,
                DogSizes = _context.DogSizes,
                Races = _context.Races,
                Customers = trainer.Customers
            };
            return View(viewModel);
        }

        // GET: Dogs/New
        public ActionResult New(int customerId)
        {
            var viewModel = new DogFormViewModel()
            {
                Dog = new DogViewModel() {CreateDate = DateTime.Now ,CustomerId = customerId},
                DogSizes = _context.DogSizes,
                Races = _context.Races,
                Genders = Settings.Genders
            };

            return View("DogForm", viewModel);
        }

        // GET: Dogs/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(DogFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("DogForm", model);
            }

            var user = await GetUser();
            if(user == null)return HttpNotFound();

            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == model.Dog.CustomerId && c.TrainerId == user.TrainerId);
            if (customer == null) return HttpNotFound();

            if (model.Dog.Id == 0)
            {
                var newDog = Mapper.Map<DogViewModel, Dog>(model.Dog);
                newDog.Vaccines = new List<Vaccine>();
                _context.Dogs.Add(newDog);
                await _context.SaveChangesAsync();
            }
            else
            {
                var dogInDb = await _context.Dogs
                    .Include(d=>d.DogSize)
                    .Include(d=>d.Race)
                    .SingleOrDefaultAsync(d => d.Id == model.Dog.Id);
                if (dogInDb == null) return HttpNotFound();
                Mapper.Map(model.Dog, dogInDb);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Dogs", "Customers", new { @customerId = model.Dog.CustomerId});
        }

        // GET: Dogs/Edit/id 
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var dog = await _context.Dogs.SingleOrDefaultAsync(d => d.Id == id);
            if (dog == null) return HttpNotFound();

            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == dog.CustomerId && c.TrainerId == user.TrainerId);
            if (customer == null) return HttpNotFound();

            var dogviewModel = Mapper.Map<Dog, DogViewModel>(dog);

            var viewModel = new DogFormViewModel()
            {
                Dog = dogviewModel,
                DogSizes = _context.DogSizes,
                Races = _context.Races,
                Genders = Settings.Genders
            };
            return View("DogForm", viewModel);
        }

        // GET: Dogs/Details/id
        public async Task<ActionResult> Details(int id)
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var dog = await _context.Dogs.SingleOrDefaultAsync(d => d.Id == id);
            if (dog == null) return HttpNotFound();

            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == dog.CustomerId && c.TrainerId == user.TrainerId);
            if (customer == null) return HttpNotFound();

            var dogviewModel = Mapper.Map<Dog, DogViewModel>(dog);

            var viewModel = new DogFormViewModel()
            {
                Dog = dogviewModel,
                DogSizes = _context.DogSizes,
                Races = _context.Races,
                Customers = _context.Customers.Where(c=>c.TrainerId == user.TrainerId),
                Genders = Settings.Genders
            };

            return View(viewModel);
        }

        // Post: Dogs/Delete/id 
        [HttpPost]
        public async Task<ActionResult> Delete(int id) 
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var dog = await _context.Dogs.SingleOrDefaultAsync(d => d.Id == id);
            if (dog == null) return HttpNotFound();

            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == dog.CustomerId && c.TrainerId == user.TrainerId);
            if (customer == null) return HttpNotFound();

            _context.Dogs.Remove(dog);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dogs", "Customers", new { @customerId = dog.CustomerId });
        }
    }
}