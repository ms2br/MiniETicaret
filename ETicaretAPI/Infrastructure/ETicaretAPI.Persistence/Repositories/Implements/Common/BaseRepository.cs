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
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        PostgreSQLDbContext _pdb { get; }

        public BaseRepository(PostgreSQLDbContext pdb)
        {
            _pdb = pdb;
        }

        public DbSet<T> Table => _pdb.Set<T>();

        public async Task<T?> FindAsync(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes)
        {
            IQueryable<T> query = includes.Length > 0 ? includeRelations(Table.AsQueryable(), includes) : Table.AsQueryable();

            return isTracking ? await query.FirstAsync(expression) : await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<T?> FindByIdAsync(string id, bool isTracking = true, params string[] includes)
        {

            IQueryable<T> query = includes.Length > 0 ? includeRelations(Table.AsQueryable(), includes) : Table.AsQueryable();

            return isTracking? await query.FirstOrDefaultAsync(x=> x.Id == Guid.Parse(id)) : await query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task SaveChangesAsync()
        => await _pdb.SaveChangesAsync();

        protected IQueryable<T> includeRelations(IQueryable<T> query, params string[] includes)
        {
            foreach (string item in includes)
                query = query.Include(item);
            return query;
        }
    }
}
