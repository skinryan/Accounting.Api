using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var primary = await _categoryRepository.GetPrimaryCategoryAsync();
            return new JsonResult(primary);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetPrimaryWithChildren()
        {
            var primary = await _categoryRepository.GetPrimaryCategoryWithChildrenAsync();
            return new JsonResult(primary);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrimary(int id)
        {
            var primary = await _categoryRepository.GetPrimaryCategoryAsync(id);
            return new JsonResult(primary.SecondaryCategory);
        }
    }
}
