using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application
{
    public class Customer
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public DateTime CreateDate { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Sex { get; set; }
        public string City { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public string HowYouGetUs { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Dog> DogList { get; set; }
    }
}