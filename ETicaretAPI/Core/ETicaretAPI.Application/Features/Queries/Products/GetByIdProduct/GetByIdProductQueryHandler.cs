using ETicaretAPI.Application.Repositories.Interfaces.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Products.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        IProductReadRepository _readRepository { get; }

        public GetByIdProductQueryHandler(IProductReadRepository readRepository)
        {
            _readRepository = readRepository;  
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var item = await _readRepository.FindByIdAsync(request.Id);
            return new GetByIdProductQueryResponse
            {
                Name = item.Name,
                Price = item.Price,
                Stock = item.Stock
            };
        }
    }
}
