using ETicaretAPI.Application.Dtos.Products;
using ETicaretAPI.Application.Features.Commands.ProductFiles.CreateProductFile;
using ETicaretAPI.Application.Features.Commands.ProductFiles.RemoveProductFile;
using ETicaretAPI.Application.Features.Commands.Products.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Products.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.Products.UpdateProduct;
using ETicaretAPI.Application.Features.Queries.ProductFiles;
using ETicaretAPI.Application.Features.Queries.Products.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Products.GetByIdProduct;
using ETicaretAPI.Application.Helpers.File;
using ETicaretAPI.Application.Repositories.Interfaces.Files;
using ETicaretAPI.Application.Repositories.Interfaces.ProductImageFiles;
using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Application.Services.Interfaces.Paginations;
using ETicaretAPI.Application.Services.Interfaces.Storage;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.InteropServices;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator { get; }
        IRequestInfoService _requestService { get; }


        public ProductsController(           
            IMediator mediator,
            IRequestInfoService requestService)
        {
            _mediator = mediator;
            _requestService = requestService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAsync(GetAllProductQueryRequest? productQueryRequest)
        {
            productQueryRequest = new();
            productQueryRequest.pagination = _requestService.GetPagination();
            return Ok(await _mediator.Send(productQueryRequest));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]GetByIdProductQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostAsync([FromBody] CreateProductCommonRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] string Id ,[FromBody] UpdateProductCommonRequest request)
        {
            request.Id = Id;
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]RemoveProductCommonRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UploadAsync([FromRoute]CreateProductFileCommonRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductImagesAsync([FromRoute] GetProductFileQueryRequest request)
        {
          
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("[action]/{id?}")]
        public async Task<IActionResult> DeleteProductImageAsync([FromRoute]string id,[FromQuery] RemoveProductFileCommonRequest request)
        {
            request.ProductId = id;
            await _mediator.Send(request);
            return Ok();
        }
    }
}
