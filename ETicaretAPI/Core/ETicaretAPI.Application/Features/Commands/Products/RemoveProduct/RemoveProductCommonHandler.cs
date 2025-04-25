using ETicaretAPI.Application.Repositories.Interfaces.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Products.RemoveProduct
{
    public class RemoveProductCommonHandler
        : IRequestHandler<RemoveProductCommonRequest>
    {
        IProductWriteRepository _productWriteRepository { get; }

        public RemoveProductCommonHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task Handle(RemoveProductCommonRequest request, CancellationToken cancellationToken)
        {
             _productWriteRepository.Remove(await _productWriteRepository.FindByIdAsync(request.Id));
        }
    }
}
