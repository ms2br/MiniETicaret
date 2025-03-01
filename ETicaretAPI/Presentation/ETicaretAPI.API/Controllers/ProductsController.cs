using ETicaretAPI.Application.Repositories.Interfaces.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(IProductWriteRepository wr, IProductReadRepository rr = null)
        {
            _wr = wr;
            _rr = rr;
        }

        IProductWriteRepository _wr { get; }
        IProductReadRepository _rr { get; }
        [HttpPost("[action]")]
        public async Task Add()
        {
            await _wr.AddAsync(new Product
            {
                Name = "aasasasas",
                Price = 12,
                Stock = 21
            });

            await _wr.SaveChangesAsync();
        }
    }
}
