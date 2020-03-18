namespace Tapas.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Tapas.Data.Models;

    public class AllergensProductsConfiguration : IEntityTypeConfiguration<AllergensProducts>
    {
        public void Configure(EntityTypeBuilder<AllergensProducts> builder)
        {
            builder
                .HasKey(x => new { x.AllergenId, x.ProductId });
        }
    }
}
