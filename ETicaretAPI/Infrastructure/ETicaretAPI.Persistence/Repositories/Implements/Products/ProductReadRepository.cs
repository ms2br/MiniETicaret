using ETicaretAPI.Application.Repositories.Interfaces.Common;
using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories.Implements.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Implements.Products
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(PostgreSQLDbContext pdb) : base(pdb)
        {
        }
    }
}
