using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.DTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; } = default!;

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
    }
}
