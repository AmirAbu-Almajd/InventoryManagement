using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Services;
using InventoryManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductPriceController : ControllerBase
    {
        private readonly IProductPriceService _productPricesService;

        public ProductPriceController(IProductPriceService productPricesService)
        {
            _productPricesService = productPricesService;
        }

        [HttpGet(Name = $"{nameof(ProductPriceService.GetAllProductPricesAsync)}")]
        public async Task<ActionResult<IEnumerable<ProductPrice>>> GetAll()
        {
            var productPrices = await _productPricesService.GetAllProductPricesAsync();
            return Ok(productPrices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPrice>> GetById(long id)
        {
            var productPrice = await _productPricesService.GetProductPriceByIdAsync(id);
            if (productPrice == null) return NotFound();
            return Ok(productPrice);
        }

        [HttpPost("{ProductPrice}")]
        public async Task<ActionResult> Create([FromBody] ProductPriceDto dto)
        {
            await _productPricesService.AddProductPriceAsync(dto);
            return CreatedAtAction(nameof(GetAll), null);
        }

        [HttpPut("{ProductPrice}")]
        public async Task<ActionResult> Update(ProductPriceDto dto)
        {
            await _productPricesService.UpdateProductPriceAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _productPricesService.DeleteProductPriceAsync(id);
            return NoContent();
        }
    }
}
