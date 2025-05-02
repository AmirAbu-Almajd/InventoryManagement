using InventoryManagement.Application.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Domain.Entities
{
    public class StockRecordDto
    {
        public long? Id { get; set; }
        public decimal Quantity { get; set; }
        public ProductDto ProductDto { get; set; }

    }
}
