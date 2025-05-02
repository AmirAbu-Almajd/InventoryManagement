
namespace InventoryManagement.Application.DTOs
{
    public class ProductPriceDto
    {
        public long? Id { get; set; }
        public decimal Price { get; set; }
        public ProductDto ProductDto { get; set; }
    }
}
