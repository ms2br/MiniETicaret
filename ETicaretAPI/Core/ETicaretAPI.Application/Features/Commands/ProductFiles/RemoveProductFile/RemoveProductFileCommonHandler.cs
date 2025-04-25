using ETicaretAPI.Application.Repositories.Interfaces.ProductImageFiles;
using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Application.Services.Interfaces.Storage;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductFiles.RemoveProductFile
{
    public class RemoveProductFileCommonHandler
        : IRequestHandler<RemoveProductFileCommonRequest>
    {

        IProductReadRepository _productReadRepository { get; }
        IStorageService _service { get; }
        IProductImageFileWriteRepository _img { get; }


        public RemoveProductFileCommonHandler(IProductReadRepository productReadRepository, IStorageService service, IProductImageFileWriteRepository img)
        {
            _productReadRepository = productReadRepository;
            _service = service;
            _img = img;
        }



        public async Task Handle(RemoveProductFileCommonRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productReadRepository.FindByIdAsync(request.ProductId,true, "Files.ProductImageFile");
            ProductFile? item = product.Files?.FirstOrDefault(x => x.FileId == Guid.Parse(request.ImageId));
            _img.Remove(item.ProductImageFile);
            await _img.SaveChangesAsync();
        }
    }
}
