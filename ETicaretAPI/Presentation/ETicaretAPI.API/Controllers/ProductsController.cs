using ETicaretAPI.Application.Dtos.Products;
using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.Services.Interfaces;
using ETicaretAPI.Application.Services.Interfaces.Storage;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Infrastructure.Helpers;
using ETicaretAPI.Infrastructure.Services.Implements;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductWriteRepository _wr { get; }
        IProductReadRepository _rr { get; }
        IStorageService _service { get; }

        public ProductsController(
            IProductWriteRepository wr,
            IProductReadRepository rr,
            IWebHostEnvironment webHostEnvironment,
            IStorageService service)
        {
            _wr = wr;
            _rr = rr;
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAsync([FromQuery] Pagination pagination)
        {
            var totalCount = _rr.GetAll().Count();
            var listProduct = _rr.GetAll().Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(x => new
            {
                x.Id,
                x.Name,
                x.Price,
                x.Stock,
                x.CreationTime,
                x.UpdateTime
            });

            return Ok(new
            {
                totalCount,
                listProduct
            });
        }

        [HttpGet("[action]/{id?}")]
        public async Task<IActionResult> GetByIdAsync(string? id)
        {
            return Ok(await _rr.FindByIdAsync(id, false));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostAsync(ProductCreateDto dto)
        {
            for (int i = 0; i < 10; i++)
            {
                await _wr.AddAsync(new Product
                {
                    Name = $"Urun {i}",
                    Stock = i,
                    Price = i
                });
                await _wr.SaveChangesAsync();
            }
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("[action]/{id?}")]
        public async Task<IActionResult> PutAsync(string? id, ProductUpdateDto dto)
        {
            var item = await _wr.FindByIdAsync(id);
            item.Name = dto.Name;
            item.Stock = dto.Stock;
            item.Price = dto.Price;
            await _wr.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("[action]/{id?}")]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            _wr.Remove(await _wr.FindByIdAsync(id));
            await _wr.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadAsync()
        {
            await _service.UploadAsync(FilesPath.ProductImageFilesPath, Request.Form.Files);
            return Ok();
        } 
    }
}
