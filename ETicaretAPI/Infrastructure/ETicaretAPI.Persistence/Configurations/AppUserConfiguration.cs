using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(48);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(48);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Ignore(x => x.UserName)
                .Ignore(x => x.NormalizedUserName)
                .Ignore(x => x.PhoneNumberConfirmed)
                .Ignore(x => x.PhoneNumber);
        }
    }
}
