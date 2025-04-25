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
    public class ProductFileConfiguration : IEntityTypeConfiguration<ProductFile>
    {
        public void Configure(EntityTypeBuilder<ProductFile> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.FileId });

            builder.HasOne(p => p.Product)
                .WithMany(p => p.Files)
                .HasForeignKey(p => p.ProductId);

            builder.HasOne(p => p.ProductImageFile)
                .WithMany()
                .HasForeignKey(x => x.FileId);
        }
    }
}
