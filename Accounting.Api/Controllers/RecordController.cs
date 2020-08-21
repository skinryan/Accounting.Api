using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Entities;
using Accounting.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordRepository _recordRepository;

        public RecordController(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository ?? throw new ArgumentNullException(nameof(recordRepository));
        }

        [HttpGet("{type}/{date}")]
        public async Task<IActionResult> GetRecords(QueryType type, DateTime date)
        {
            var records = await _recordRepository.GetRecordsAsync(date, type);
            return new JsonResult(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecord(int id)
        {
            var records = await _recordRepository.GetRecordsAsync(id);
            return new JsonResult(records);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Record>> Delete(int id)
        {
            var record = await _recordRepository.GetRecordsAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _recordRepository.DeleteRecord(record);
            await _recordRepository.SaveAsync();

            return record;
        }

        [HttpPost]
        public async Task<ActionResult<Record>> PostSecondaryCategory(Record record)
        {
            _recordRepository.AddRecord(record);
            await _recordRepository.SaveAsync();

            return CreatedAtAction("GetRecord", new { id = record.Id }, record);
        }
    }
}
