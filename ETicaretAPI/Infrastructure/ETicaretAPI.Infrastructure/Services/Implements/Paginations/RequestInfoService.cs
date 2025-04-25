using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.Services.Interfaces.Paginations;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Implements.Paginations
{
    public class RequestInfoService : IRequestInfoService
    {
        IHttpContextAccessor _httpContextAccessor { get; }

        public RequestInfoService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Pagination GetPagination()
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
                return new Pagination();
            var query = request.Query;
            int.TryParse(query["page"], out int page);
            int.TryParse(query["size"], out int size);
            return new Pagination
            {
                Page = page > 0 ? page : 0,
                Size = size > 0 ? size : 5
            };
        }
    }
}
