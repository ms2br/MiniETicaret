using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<Domain.Entities.File>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.File> builder)
        {
            builder.Ignore(x => x.UpdateTime);

            builder.Property(x => x.FileName)
                .IsRequired();

            builder.Property(x => x.Path)
                .IsRequired();

            builder.Property(x => x.StorageName)
                .IsRequired();
        }
    }
}
