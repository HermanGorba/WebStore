using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.DTOs
{
    public class ChangePasswordDTO
    {
        public Guid Id { get; set; } = default!;

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "Current Password is required")]
        [Display(Name = "Current password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; } = default!;
        [Required(ErrorMessage = "New Password is required")]
        [Display(Name = "New password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = default!;
    }
}
