using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories.Interfaces.Common
{
    public interface IWriteRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T data);
        Task<bool> AddRangesAsync(List<T> datas);
        Task<bool> UpdateAsync(T data);
        bool Remove(T data);
    }
}
