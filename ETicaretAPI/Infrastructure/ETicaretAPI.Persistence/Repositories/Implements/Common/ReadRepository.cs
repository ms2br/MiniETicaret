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
        PostgreSQLDbContext _pdb { get; }

        public ReadRepository(PostgreSQLDbContext pdb) : base(pdb)
        {
            _pdb = pdb;
        }
        public IQueryable<T> GetAll()
        => Table.AsNoTracking();

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        => Table.Where(expression).AsNoTracking();
    }
}
