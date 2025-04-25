using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.ProductFiles
{
    public class GetProductFileQueryHandler : IRequestHandler<GetProductFileQueryRequest, GetProductFileQueryResponse>
    {
        IProductReadRepository _productReadRepository { get; }
        IConfiguration _config { get; }
        public GetProductFileQueryHandler(IProductReadRepository productReadRepository, IConfiguration config)
        {
            _productReadRepository = productReadRepository;
            _config = config;
        }

        public async Task<GetProductFileQueryResponse> Handle(GetProductFileQueryRequest request, CancellationToken cancellationToken)
        {            
            Product? product = await _productReadRepository.FindByIdAsync(request.ProductId, false, "Files.ProductImageFile");
            var item = product.Files.Select(x => new
            {
                x.ProductImageFile?.FileName,
                Path = $"{_config["LocalStorageUrl"]}{x.ProductImageFile?.Path}",
                x.FileId
            });
            return new()
            {
                File = item
            };
        }
    }
}
