namespace Tapas.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Tapas.Data.Models;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasDiscriminator<string>("Discriminator")
                .HasValue<MenuProduct>("MenuProduct")
                .HasValue<CateringProduct>("CateringProduct")
                .HasValue<EquipmentForRent>("EquipmentForRent");
        }
    }
}
