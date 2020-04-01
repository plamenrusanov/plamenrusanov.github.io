namespace Tapas.Data.Configurations
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Tapas.Data.Models;

    public class ShopingCartConfiguration : IEntityTypeConfiguration<ShopingCart>
    {
        public void Configure(EntityTypeBuilder<ShopingCart> builder)
        {
            builder
                .HasOne(e => e.Customer)
                .WithOne()
                .HasForeignKey<ShopingCart>(e => e.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
