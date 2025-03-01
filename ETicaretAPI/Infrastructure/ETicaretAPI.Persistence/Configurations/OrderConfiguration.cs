using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(255);

            builder.OwnsOne(x => x.Address, p =>
            {
                p.Property(x => x.City)
                .HasMaxLength(128)
                .IsRequired();

                p.Property(x => x.Street)
                .HasMaxLength(200)
                .IsRequired();

                p.Property(x => x.State)
                .HasMaxLength(128)
                .IsRequired();

                p.Property(x => x.Country)
                .HasMaxLength(128)
                .IsRequired();

                p.Property(x => x.ZipCode)
                .HasMaxLength(20)
                .IsRequired();
            });


            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
