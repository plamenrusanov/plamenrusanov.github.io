﻿namespace Tapas.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Tapas.Data.Models;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> appUser)
        {
            appUser
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appUser
               .HasMany(e => e.Addresses)
               .WithOne()
               .HasForeignKey(e => e.CustomerId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            appUser
               .HasMany(e => e.Orders)
               .WithOne()
               .HasForeignKey(e => e.CustomerId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
