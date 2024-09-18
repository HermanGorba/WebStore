using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Models.Core;

namespace WebStore.Data.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(ph => ph.Id);

            builder.HasOne(ph => ph.Product)
                .WithMany(p => p.Photos)
                .HasForeignKey(ph => ph.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ph => ph.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(ph => ph.ImageData)
                .IsRequired();

            builder.Property(ph => ph.UploadDate)
                .IsRequired();
        }
    }
}
