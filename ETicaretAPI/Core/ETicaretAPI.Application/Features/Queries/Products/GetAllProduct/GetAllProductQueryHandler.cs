using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.Services.Interfaces.Paginations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Products.GetAllProduct
{
    public class GetAllProductQueryHandler :
        IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        IProductReadRepository _productRead { get; }
        public GetAllProductQueryHandler(IProductReadRepository productRead)
        {
            _productRead = productRead;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _productRead.GetAll().Count();
            var listProduct = _productRead.GetAll().Skip(request.pagination.Page * request.pagination.Size).Take(request.pagination.Size).Select(x => new
            {
                x.Id,
                x.Name,
                x.Price,
                x.Stock,
                x.CreationTime,
                x.UpdateTime
            }).ToList();

            return new()
            {
                ListProduct = listProduct,
                TotalCount = totalCount
            };
        }
    }
}
