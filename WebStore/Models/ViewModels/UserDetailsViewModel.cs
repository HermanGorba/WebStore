using System.ComponentModel.DataAnnotations;
using WebStore.Models.Core;

namespace WebStore.Models.ViewModels
{
    public class UserDetailsViewModel
    {
        public Guid Id {  get; set; } = default!;

        public string Login { get; set; } = default!;

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; } = default!;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
