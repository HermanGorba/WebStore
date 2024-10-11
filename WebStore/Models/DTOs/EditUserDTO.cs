using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.DTOs
{
    public class EditUserDTO
    {
        public Guid Id { get; set; } = default!;

        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; } = default!;

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = default!;
    }
}
