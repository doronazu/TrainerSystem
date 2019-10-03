using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainerSystem.ViewModels
{
    public class DogViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "תאריך יצירת לקוח")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "תמונה")]
        public string Image { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [StringLength(255)]
        [Display(Name = "שם")]
        public string Name { get; set; }

        [Display(Name = "משקל")]
        public float Weight { get; set; }

        [Display(Name = "שם ווטרינר")]
        public string VeterinarianName { get; set; }

        [Display(Name = "סוג מזון")]
        public string FoodType { get; set; }

        [Display(Name = "מסורס/מעוקר")]
        public bool Sterilized { get; set; }


        [Display(Name = "מין")]
        public int Sex { get; set; }

        [Display(Name = "תאריך לידה")]
        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "גזע")]
        public short RaceId { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "גודל")]
        public byte DogSizeId { get; set; }

        [Display(Name = "הערה")]
        public string Note { get; set; }
    }
}