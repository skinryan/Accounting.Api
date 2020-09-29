using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Entities;
using Accounting.Api.Models;
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
            var result = new Result<List<Record>>()
            {
                ErrorCode = CommonConst.ERR_CODE_SUCCESS,
                ErrorMessage = ""

            };

            try
            {
                var records = await _recordRepository.GetRecordsAsync(date, type);

                result.Data = records.ToList();

            }
            catch (Exception ex)
            {
                result.ErrorCode = CommonConst.ERR_CODE_FAIL;
                result.ErrorMessage = ex.Message;
            }

            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecord(int id)
        {
            var result = new Result<Record>()
            {
                ErrorCode = CommonConst.ERR_CODE_SUCCESS,
                ErrorMessage = ""
            };

            try
            {
                var record = await _recordRepository.GetRecordsAsync(id);
                result.Data = record;
            }
            catch (Exception ex)
            {
                result.ErrorCode = CommonConst.ERR_CODE_FAIL;
                result.ErrorMessage = ex.Message;
            }

            return new JsonResult(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<Record>>> Delete(int id)
        {
            var result = new Result<Record>()
            {
                ErrorCode = CommonConst.ERR_CODE_SUCCESS,
                ErrorMessage = ""
            };

            try
            {
                var record = await _recordRepository.GetRecordsAsync(id);
                if (record == null)
                {
                    return NotFound();
                }

                _recordRepository.DeleteRecord(record);
                await _recordRepository.SaveAsync();

                result.Data = record;
            }
            catch (Exception)
            {
                result.ErrorCode = CommonConst.ERR_CODE_FAIL;
                result.ErrorMessage = CommonConst.ERR_MSG_UNKNOW;
            }

            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Record>>> PostSecondaryCategory(Record record)
        {
            _recordRepository.AddRecord(record);
            await _recordRepository.SaveAsync();

            return CreatedAtAction("GetRecord", new { id = record.RecordId }, record);
        }
    }
}
