using ETicaretAPI.Application.Dtos.Products;
using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Domain.Entities;
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
        public ProductsController(IProductWriteRepository wr, IProductReadRepository rr)
        {
            _wr = wr;
            _rr = rr;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(_rr.GetAll());
        }

        [HttpGet("[action]/{id?}")]
        public async Task<IActionResult> GetByIdAsync(string? id)
        {
            return Ok(await _rr.FindByIdAsync(id, false));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostAsync(ProductCreateDto dto)
        {
            await _wr.AddAsync(new Product
            {
                 Name = dto.Name,
                 Price = dto.Price,
                 Stock = dto.Stock
            });
            await _wr.SaveChangesAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("[action]/{id?}")]
        public async Task<IActionResult> PutAsync(string? id,ProductUpdateDto dto)
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
    }
}
