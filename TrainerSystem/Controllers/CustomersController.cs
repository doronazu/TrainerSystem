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
    [Authorize(Roles = RoleName.Admin + "," + RoleName.Manager)]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        private async Task<ApplicationUser> GetUser()
        {
            var uid = User.Identity.GetUserId();
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == uid);
        }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public async Task<ActionResult> Index()
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var customers = await _context.Customers.Include(c=>c.DogList).Where(c => c.TrainerId == user.TrainerId).ToListAsync();

            return View(customers);
        }

        // GET: Customers/Details/{id}
        public async Task<ActionResult> Details(int id)
        {
            var user = await GetUser();

            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id && c.TrainerId == user.TrainerId);
            if (customerInDb == null) return HttpNotFound();

            var newCustomer = Mapper.Map<Customer, CustomerViewModel>(customerInDb);
            return View(newCustomer);
        }

        // GET: Customers/New
        public async Task<ActionResult> New()
        {
            var user = await GetUser();
            return View("CustomerForm",new CustomerViewModel(){CreateDate = DateTime.Now,TrainerId = user.TrainerId});
        }

        // GET: Customers/Edit/{id}
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetUser();

            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id && c.TrainerId == user.TrainerId);
            if (customerInDb == null) return HttpNotFound();

            var newCustomer = Mapper.Map<Customer,CustomerViewModel>(customerInDb);

            return View("CustomerForm", newCustomer);
        }

        // GET: Customers/Save/{Customer}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", customer);
            }

            var user = await GetUser();

            if (customer.Id == 0)
            {
                var newCustomer = Mapper.Map<CustomerViewModel, Customer>(customer);
                newCustomer.DogList = new List<Dog>();
                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();
            }
            else
            {
                var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == customer.Id && c.TrainerId == user.TrainerId);
                if (customerInDb == null) return HttpNotFound();
                Mapper.Map(customer, customerInDb);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // Post: Customers/Delete/{id}
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id && c.TrainerId == user.TrainerId);
            if (customerInDb == null) return HttpNotFound();

            _context.Customers.Remove(customerInDb);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Dogs(int customerId)
        {
            var user = await GetUser();
            if (user == null) return HttpNotFound();

            var customer =await 
                _context.Customers.Include(c => c.DogList)
                    .SingleOrDefaultAsync(c => c.Id == customerId && c.TrainerId == user.TrainerId);
            if (customer == null) return HttpNotFound();


            var list = customer.DogList.Select(Mapper.Map<Dog, DogViewModel>).ToList();

            var viewModel = new DogsViewModel()
            {
                CustomerId = customerId,
                Dogs = list,
                DogSizes = _context.DogSizes,
                Races = _context.Races
            };
            return View(viewModel);
        }
    }
}