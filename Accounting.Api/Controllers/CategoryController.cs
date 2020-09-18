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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetPrimary()
        {
            var result = new Result<List<PrimaryCategory>>()
            {
                ErrorCode = CommonConst.ERR_CODE_SUCCESS,
                ErrorMessage = ""
            };

            try
            {
                var primary = await _categoryRepository.GetPrimaryCategoryAsync();
                result.Data = primary.ToList();
            }
            catch (Exception ex)
            {
                result.ErrorCode = CommonConst.ERR_CODE_FAIL;
                result.ErrorMessage = ex.Message;
            }

            return new JsonResult(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetPrimaryWithChildren()
        {
            var result = new Result<List<PrimaryCategory>>()
            {
                ErrorCode = CommonConst.ERR_CODE_SUCCESS,
                ErrorMessage = ""

            };

            try
            {
                var primary = await _categoryRepository.GetPrimaryCategoryWithChildrenAsync();

                result.Data = primary.ToList();
            }
            catch (Exception ex)
            {
                result.ErrorCode = CommonConst.ERR_CODE_FAIL;
                result.ErrorMessage = ex.Message;
            }

            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrimary(int id)
        {
            var result = new Result<PrimaryCategory>()
            {
                ErrorCode = CommonConst.ERR_CODE_SUCCESS,
                ErrorMessage = ""
            };

            try
            {
                var primary = await _categoryRepository.GetPrimaryCategoryAsync(id);
                result.Data = primary;
            }
            catch (Exception ex)
            {
                result.ErrorCode = CommonConst.ERR_CODE_FAIL;
                result.ErrorMessage = ex.Message;
            }

            return new JsonResult(result);
        }
    }
}
