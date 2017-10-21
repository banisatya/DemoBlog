using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoBlog.DataAccess.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class UserValidationViewModel
    {
        public string UserName { get; set; }
        public bool IsValidUser { get; set; }
        public int UserID { get; set; }
        public bool IsAdminUser { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}