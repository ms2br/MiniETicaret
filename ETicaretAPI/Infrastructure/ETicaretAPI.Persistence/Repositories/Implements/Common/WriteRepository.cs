using ETicaretAPI.Application.Repositories.Interfaces.Common;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Implements.Common
{
    public class WriteRepository<T> : BaseRepository<T>, IWriteRepository<T> where T : BaseEntity
    {
        public WriteRepository(PostgreSQLDbContext pdb) : base(pdb)
        {
        }

        public async Task<bool> AddAsync(T data)
        {
            EntityEntry<T> item = await Table.AddAsync(data);
            return item.State == EntityState.Added;
        }

        public async Task<bool> AddRangesAync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T data)
        {
            Table.Remove(data);
            return true;
        }

        public async Task<bool> UpdateAsnyc(T data)
        {
            Table.Update(data);
            return true;
        }
    }
}
