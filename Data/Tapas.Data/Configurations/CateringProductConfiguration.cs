namespace Tapas.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Tapas.Data.Models;

    public class CateringProductConfiguration : IEntityTypeConfiguration<CateringProduct>
    {
        public void Configure(EntityTypeBuilder<CateringProduct> builder)
        {
            builder.HasOne(x => x.Size)
                .WithOne()
                .HasForeignKey<CateringProduct>(x => x.SizeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
