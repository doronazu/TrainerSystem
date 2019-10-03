using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerSystem.Models.Application
{
    public class Dog
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public int CustomerId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public float Weight { get; set; }
        public string VeterinarianName { get; set; }
        public string FoodType { get; set; }
        public int Sex { get; set; }

        public Race Race { get; set; }
        public short RaceId { get; set; }

        public DogSize DogSize { get; set; }
        public byte DogSizeId { get; set; }

        public bool Sterilized { get; set; }
        public string Note { get; set; }

        public List<Vaccine> Vaccines { get; set; }
    }
}