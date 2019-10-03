using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainerSystem.ViewModels
{
    public class CustomerViewModel
    {

        [Display(Name = "מספר זיהוי לקוח")]
        public int Id { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "מספר זיהוי מאלף")]
        public int TrainerId { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "תאריך יצירת לקוח")]
        public DateTime CreateDate { get; set; }


        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "שם")]
        public string Name { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "פלאפון")]
        public string Phone { get; set; }

        [Display(Name = "כתובת")]
        public string Address { get; set; }

        [Display(Name = "מין")]
        public int Sex { get; set; }

        [Display(Name = "עיר")]
        public string City { get; set; }

        [Display(Name = "איש קשר")]
        public string ContactName { get; set; }

        [Display(Name = "פלאפון איש קשר")]
        public string ContactPhone { get; set; }

        [Display(Name = "מייל")]
        public string Email { get; set; }

        [Display(Name = "איך הגעת אלינו")]
        public string HowYouGetUs { get; set; }

        [Display(Name = "תאריך לידה")]
        public DateTime? Birthdate { get; set; }
    }
}