using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Models.Core;

namespace WebStore.Data.Configurations
{
    public class WebStoreUserConfiguration : IEntityTypeConfiguration<WebStoreUser>
    {
        public void Configure(EntityTypeBuilder<WebStoreUser> builder)
        {
            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
