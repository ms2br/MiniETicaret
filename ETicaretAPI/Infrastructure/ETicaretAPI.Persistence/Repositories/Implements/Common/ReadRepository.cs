using ETicaretAPI.Application.Repositories.Interfaces.Common;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Implements.Common
{
    public class ReadRepository<T> : BaseRepository<T> 
        , IReadRepository<T> where T : BaseEntity
    {
        public ReadRepository(PostgreSQLDbContext pdb) : base(pdb)
        {

        }
        public IQueryable<T> GetAll(params string[] includes)
        {
            IQueryable<T> query = includes.Length > 0 ? includeRelations(Table.AsQueryable(), includes) : Table.AsQueryable();

            return query.AsNoTracking();
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, params string[] includes)
        {
            IQueryable<T> query = includes.Length > 0 ? includeRelations(Table.AsQueryable(), includes) : Table.AsQueryable();

            return query.Where(expression).AsNoTracking();
        }

    }
}
