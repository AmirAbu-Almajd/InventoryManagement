using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Services;
using InventoryManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockRecordController : ControllerBase
    {
        private readonly IStockRecordService _stockRecordService;

        public StockRecordController(IStockRecordService stockRecordService)
        {
            _stockRecordService = stockRecordService;
        }

        [HttpGet(Name = $"{nameof(StockRecordService.GetAllStockRecordsAsync)}")]
        public async Task<ActionResult<IEnumerable<StockRecordDto>>> GetAll()
        {
            var stockRecords = await _stockRecordService.GetAllStockRecordsAsync();
            return Ok(stockRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockRecordDto>> GetById(long id)
        {
            var stockRecord = await _stockRecordService.GetStockRecordByIdAsync(id);
            if (stockRecord == null) return NotFound();
            return Ok(stockRecord);
        }

        [HttpPost("{SalesRecord}")]
        public async Task<ActionResult> Create([FromBody] StockRecordDto dto)
        {
            await _stockRecordService.AddStockRecordAsync(dto);
            return CreatedAtAction(nameof(GetAll), null);
        }

        [HttpPut("{SalesRecord}")]
        public async Task<ActionResult> Update([FromBody] StockRecordDto dto)
        {
            await _stockRecordService.UpdateStockRecordAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _stockRecordService.DeleteStockRecordAsync(id);
            return NoContent();
        }
    }
}
