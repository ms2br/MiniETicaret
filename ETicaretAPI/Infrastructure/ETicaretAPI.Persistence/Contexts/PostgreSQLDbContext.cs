using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using File = ETicaretAPI.Domain.Entities.File;

namespace ETicaretAPI.Persistence.Contexts
{
    public class PostgreSQLDbContext : IdentityDbContext<AppUser>
    {
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<ProductOrder> ProductOrder { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<InvoiceFile> InvoiceFiles { get; set; }
        DbSet<ProductImageFile> ProductImageFiles { get; set; }
        DbSet<ProductFile> ProductFiles { get; set; }
        public PostgreSQLDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreationTime = DateTime.UtcNow;
                    entity.Entity.Id = Guid.NewGuid();
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdateTime = DateTime.UtcNow;
                }
                else if (entity.State == EntityState.Deleted)
                {
                    entity.Entity.IsDelete = true;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
