
using InventoryManagement.Application.DTOs;

namespace InventoryManagement.Domain.Entities
{
    public class SalesRecordDto
    {
        public long? Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public ProductDto ProductDto { get; set; }
    }
}
