using Microsoft.AspNetCore.Identity;

namespace WebStore.Models.Core
{
    public class WebStoreUser : IdentityUser<Guid>
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
