using ETicaretAPI.Application.Helpers.File;
using ETicaretAPI.Application.Repositories.Interfaces.ProductImageFiles;
using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Application.Services.Interfaces.Storage;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.ProductFiles.CreateProductFile
{
    public class CreateProductFileCommonHandler : IRequestHandler<CreateProductFileCommonRequest>
    {

        public IProductWriteRepository _productWriteRepository { get; }
        public IProductImageFileWriteRepository _fileWriteRepository { get; }
        public IStorageService _service { get; }
        public IHttpContextAccessor _fileRequest { get;  }

        public CreateProductFileCommonHandler(IProductWriteRepository productWriteRepository, IProductImageFileWriteRepository fileWriteRepository, IStorageService service, IHttpContextAccessor fileRequest)
        {
            _productWriteRepository = productWriteRepository;
            _fileWriteRepository = fileWriteRepository;
            _service = service;
            _fileRequest = fileRequest;
        }

        public async Task Handle(CreateProductFileCommonRequest request, CancellationToken cancellationToken)
        {
            Product data = await _productWriteRepository.FindByIdAsync(request.ProductId);
            var files = await _service.UploadAsync(FilesPath.ProductImageFilesPath,_fileRequest.HttpContext.Request.Form.Files);
            data.Files = new List<ProductFile>();
            foreach (var file in files)
            {
                data.Files.Add(new ProductFile
                {
                    ProductImageFile = new()
                    {
                        FileName = file.NewFileName,
                        Path = file.Path,
                        StorageName = _service.StorageName
                    }
                });
            }
            await _fileWriteRepository.SaveChangesAsync();
        }
    }
}
