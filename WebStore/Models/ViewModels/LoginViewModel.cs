using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password in required")]
        [DataType(DataType.Password, ErrorMessage = "Password is not secure enough.")]
        [Display(Name = "Password")]
        public string Password { get; set; } = default!;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; } = default!;
    }
}
