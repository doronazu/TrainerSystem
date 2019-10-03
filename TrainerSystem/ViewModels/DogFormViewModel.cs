using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainerSystem.Models.Application;

namespace TrainerSystem.ViewModels
{
    public class DogFormViewModel
    {
        public DogViewModel Dog { get; set; }
        public IEnumerable<DogSize> DogSizes { get; set; }
        public IEnumerable<Race> Races { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}