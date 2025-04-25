using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Products.CreateProduct
{
    public class CreateProductCommonHandler : IRequestHandler<CreateProductCommonRequest>
    {
        IProductWriteRepository _productWriteRepository { get; }

        public CreateProductCommonHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task Handle(CreateProductCommonRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.AddAsync(new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            });
        }
    }
}
