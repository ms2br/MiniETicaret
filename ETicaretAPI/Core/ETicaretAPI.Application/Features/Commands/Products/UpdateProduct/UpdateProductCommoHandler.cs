using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Products.UpdateProduct
{
    public class UpdateProductCommoHandler : IRequestHandler<UpdateProductCommonRequest>
    {
        IProductWriteRepository _productWriteRepository { get; }

        public UpdateProductCommoHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task Handle(UpdateProductCommonRequest request, CancellationToken cancellationToken)
        {
            Product item = await _productWriteRepository.FindByIdAsync(request.Id);
            item.Name = request.Name;
            item.Price = request.Price;
            item.Stock = request.Stock;
            await _productWriteRepository.SaveChangesAsync();
        }
    }
}
