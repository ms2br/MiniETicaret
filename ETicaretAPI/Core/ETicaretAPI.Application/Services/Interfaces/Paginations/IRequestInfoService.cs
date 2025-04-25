using ETicaretAPI.Application.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Services.Interfaces.Paginations
{
    public interface IRequestInfoService
    {
        Pagination GetPagination();
    }
}
