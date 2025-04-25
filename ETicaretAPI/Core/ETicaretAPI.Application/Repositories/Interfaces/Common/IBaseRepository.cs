using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories.Interfaces.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        protected DbSet<T> Table { get; }
        Task<T?> FindAsync(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes);
        Task<T?> FindByIdAsync(string id,bool isTracking = true, params string[] includes);
        Task SaveChangesAsync();

    }
}
