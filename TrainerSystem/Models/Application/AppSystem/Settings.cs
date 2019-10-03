using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application.AppSystem
{
    public static class Settings
    {
        public static List<Level> Levels { get; set; }
        public static List<Gender> Genders { get; set; }
        private static ApplicationDbContext _context;
        static Settings()
        {
            _context = new ApplicationDbContext();
            Levels = new List<Level>()
            {
                new Level()
                {
                    Id = 1,
                    Name = "מנהל"
                },
                new Level()
                {
                    Id = 2,
                    Name = "משתמש רשום"
                }
            };
            Genders = new List<Gender>()
            {
                new Gender()
                {
                    Id = 1,
                    Name = "זכר"
                },
                new Gender()
                {
                    Id = 2,
                    Name = "נקבה"
                }
            };
        }


        public static Trainer GetTrainerByUserId(string uid)
        {
            Trainer temp = null;
            var user = _context.Users.SingleOrDefault(u => u.Id == uid);
            if (user == null) return null;
            temp = _context.Trainers.SingleOrDefault(t => t.Id == user.TrainerId);

            return temp;
        }
        public static bool IsInRole(string id, string role)
        {
            var ro = _context.Roles.Include(rd => rd.Users).SingleOrDefault(rd => rd.Name == role);
            var user = ro.Users.SingleOrDefault(u => u.UserId == id);
            if (user == null) return false;

            return true;
        }


        public static string GetNumberSort(int number)
        {
            var fee = "";
            if (number > 999 && number < 10000)
            {
                var temp = number.ToString();
                for (int i = 0; i < temp.Length; i++)
                {
                    if (i == 1)
                    {
                        fee += ',';
                    }
                    fee += temp[i];
                }
            }
            else if (number > 9999 && number < 100000)
            {
                var temp = number.ToString();
                for (int i = 0; i < temp.Length; i++)
                {
                    if (i == 2)
                    {
                        fee += ',';
                    }
                    fee += temp[i];
                }
            }
            else
            {
                fee = number.ToString();
            }

            return fee;
        }
        public static string GetNumberSort(double number)
        {
            var fee = "";
            if (number > 999 && number < 10000)
            {
                var temp = number.ToString();
                for (int i = 0; i < temp.Length; i++)
                {
                    if (i == 1)
                    {
                        fee += ',';
                    }
                    fee += temp[i];
                }
            }
            else if (number > 9999 && number < 100000)
            {
                var temp = number.ToString();
                for (int i = 0; i < temp.Length; i++)
                {
                    if (i == 2)
                    {
                        fee += ',';
                    }
                    fee += temp[i];
                }
            }
            else
            {
                fee = number.ToString();
            }

            return fee;
        }

        public static byte GetLevelByUser(ApplicationUser user)
        {
            var roles = _context.Roles.ToList();
            var userRoles = user.Roles.ToList();
            foreach (var urole in userRoles)
            {
                var tr = roles.SingleOrDefault(r => r.Id == urole.RoleId);
                if (tr != null)
                {
                    switch (tr.Name)
                    {
                        case "Admin":
                            return 1;
                        case "Manager":
                            return 2;
                    }
                }
            }
            return 0;
        }

        public static Trainer GetTrainer(int id)
        {
            var context = new ApplicationDbContext();

            var trainer = context.Trainers
                .Include(t => t.Customers)
                .Include(t => t.Shop)
                .Include(t => t.Packages)
                .SingleOrDefault(t => t.Id == id);
            if (trainer == null) return null;
            var dogList = context.Dogs
                .Include(d => d.Vaccines)
                .Include(d => d.Race)
                .Include(d => d.DogSize).ToList();
            foreach (var customer in trainer.Customers)
            {
                customer.DogList = dogList.Where(d => d.CustomerId == customer.Id).ToList();
            }
            return trainer;
        }


    }
}