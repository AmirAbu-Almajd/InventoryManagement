using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Services;
using InventoryManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesRecordController : ControllerBase
    {
        private readonly ISalesRecordService _salesRecordService;

        public SalesRecordController(ISalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        [HttpGet(Name = $"{nameof(SalesRecordService.GetAllSalesRecordsAsync)}")]
        public async Task<ActionResult<IEnumerable<SalesRecordDto>>> GetAll()
        {
            var salesRecords = await _salesRecordService.GetAllSalesRecordsAsync();
            return Ok(salesRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesRecordDto>> GetById(long id)
        {
            var salesRecord = await _salesRecordService.GetSalesRecordByIdAsync(id);
            if (salesRecord == null) return NotFound();
            return Ok(salesRecord);
        }

        [HttpPost("{SalesRecord}")]
        public async Task<ActionResult> Create([FromBody] SalesRecordDto dto)
        {
            await _salesRecordService.AddSalesRecordAsync(dto);
            return CreatedAtAction(nameof(GetAll), null);
        }

        [HttpPut("{SalesRecord}")]
        public async Task<ActionResult> Update([FromBody] SalesRecordDto dto)
        {
            await _salesRecordService.UpdateSalesRecordAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _salesRecordService.DeleteSalesRecordAsync(id);
            return NoContent();
        }
    }
}
