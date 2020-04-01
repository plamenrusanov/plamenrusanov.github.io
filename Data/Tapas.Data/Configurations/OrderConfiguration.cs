namespace Tapas.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Tapas.Data.Models;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasMany(e => e.CartItems)
                .WithOne()
                .HasForeignKey(e => e.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Address)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.AddressId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Customer)
                .WithMany()
                .HasForeignKey(e => e.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
