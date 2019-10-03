using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Tasks;
using TrainerSystem.Models.Application;

namespace TrainerSystem.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "מייל")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "מייל")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמא")]
        public string Password { get; set; }

        [Display(Name = "זכור אותי?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [EmailAddress(ErrorMessage = "כתובת מייל אינה תקינה")]
        [Display(Name = "מייל")]
        public string Email { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "שם מלא")]
        public string Name { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "מסלול רכישה")]
        public byte MembershipTypeId { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "מין")]
        public int Sex { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [StringLength(100, ErrorMessage = "ה{0} צריכה להכיל לפחות {2} תווים", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמא")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "אישור סיסמא")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage="הסיסמא צריכה להכיל לפחות או גדולה ואות קטנה באנגלית")]
        [Compare("Password", ErrorMessage = "שדה סיסמא ושדה אישור סיסמא אינם תואמים")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "הרשאות")]
        public byte Level { get; set; }
    }

    public class EditUserViewModel
    {
        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "מס זיהוי")]
        public string Id { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [EmailAddress(ErrorMessage = "כתובת מייל אינה תקינה")]
        [Display(Name = "מייל")]
        public string Email { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "שם מלא")]
        public string Name { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "מין")]
        public int Sex { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "מסלול רכישה")]
        public byte MembershipTypeId { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "הרשאות")]
        public byte Level { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [EmailAddress(ErrorMessage = "כתובת מייל אינה תקינה")]
        [Display(Name = "מייל")]
        public string Email { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "שם מלא")]
        public string Name { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "מין")]
        public int Sex { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [Display(Name = "מסלול רכישה")]
        public byte MembershipTypeId { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [StringLength(100, ErrorMessage = "ה{0} צריכה להכיל לפחות {2} תווים", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמא")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "אישור סיסמא")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage="הסיסמא צריכה להכיל לפחות או גדולה ואות קטנה באנגלית")]
        [Compare("Password", ErrorMessage = "שדה סיסמא ושדה אישור סיסמא אינם תואמים")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [EmailAddress]
        [Display(Name = "מייל")]
        public string Email { get; set; }

        [Required(ErrorMessage = "שדה {0} הינו שדה חובה")]
        [StringLength(100, ErrorMessage = "ה{0} צריכה להכיל לפחות {2} תווים", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמא")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "אישור סיסמא")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "הסיסמא צריכה להכיל לפחות או גדולה ואות קטנה באנגלית")]
        [Compare("Password", ErrorMessage = "שדה סיסמא ושדה אישור סיסמא אינם תואמים")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
