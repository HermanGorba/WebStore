using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebStore.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; } = default!;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [DisplayName("Email")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password, ErrorMessage = "Password is not secure enough")]
        [DisplayName("Password")]
        public string Password { get; set; } = default!;
        [Required(ErrorMessage = "You must confirm password")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = default!;
    }
}
