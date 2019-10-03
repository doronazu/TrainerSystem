using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainerSystem.ViewModels
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [StringLength(255)]
        [Display(Name = "שם")]
        public string Name { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [StringLength(255)]
        [Display(Name = "תיאור")]
        public string Description { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "מחיר")]
        public double Price { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "הנחה")]
        public short Discount { get; set; }

        [Display(Name = "תמונה")]
        public string Image { get; set; }
    }
}