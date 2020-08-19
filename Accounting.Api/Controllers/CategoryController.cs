using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api.Controllers
{
    [Route("api/category")]
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
            var primary = await _categoryRepository.GetAllPrimaryCategoryAsync();
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
