using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, Name = "Product 1", Price = 100, Stock = 10 },
            //    new() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, Name = "Product 2", Price = 200, Stock = 20 },
            //    new() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, Name = "Product 3", Price = 300, Stock = 150 },
            //});
            //await _productWriteRepository.SaveAsync();

            var product = await _productReadRepository.GetByIdAsync("5dbc0c67-76a1-4c05-90de-14f7ef1ad01f");
            product.Name = "Product 3";
            await _productWriteRepository.SaveAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
