using ETicaretAPI.Application.Repositories.Interfaces.Common;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories.Interfaces.Orders
{
    public interface IOrderWriteRepository : IWriteRepository<Order>
    {
    }
}
