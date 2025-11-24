using Code.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Code.Services;
using Code.Infrastructure.Entities;
namespace BlogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly Code.Services.BlogService _blogService;

        public BlogController(IUnitOfWork unitOfWork)
        {
            _blogService = new Code.Services.BlogService(unitOfWork);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _blogService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _blogService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blogmodel product)
        {
            var id = await _blogService.CreateAsync(product);
            return CreatedAtAction(nameof(Get), new { id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blogmodel product)
        {
            if (id != product.Id)
                return BadRequest();

            await _blogService.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("in-stock")]
        public async Task<IActionResult> GetInStock()
        {
            var products = await _blogService.GetProductsInStockAsync();
            return Ok(products);
        }
    }
}
