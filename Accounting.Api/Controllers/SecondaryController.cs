using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Accounting.Api.DbContexts;
using Accounting.Api.Entities;
using Accounting.Api.Models;

namespace Accounting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondaryController : ControllerBase
    {
        private readonly AccountingDbContext _context;

        public SecondaryController(AccountingDbContext context)
        {
            _context = context;
        }

        // GET: api/Secondary
        [HttpGet]
        public async Task<ActionResult<Result<List<SecondaryCategory>>>> GetsecondaryCategories()
        {
            var result = new Result<List<SecondaryCategory>>()
            {
                ErrorCode = CommonConst.ERR_CODE_SUCCESS,
                ErrorMessage = ""
            };

            try
            {
                result.Data = await _context.secondaryCategories.Include(t => t.PrimaryCategory).ToListAsync();
            }
            catch (Exception ex)
            {
                result.ErrorCode = CommonConst.ERR_CODE_FAIL;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        // GET: api/Secondary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SecondaryCategory>> GetSecondaryCategory(int id)
        {
            var secondaryCategory = await _context.secondaryCategories.FindAsync(id);

            if (secondaryCategory == null)
            {
                return NotFound();
            }

            return secondaryCategory;
        }

        // PUT: api/Secondary/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecondaryCategory(int id, SecondaryCategory secondaryCategory)
        {
            if (id != secondaryCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(secondaryCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecondaryCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Secondary
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SecondaryCategory>> PostSecondaryCategory(SecondaryCategory secondaryCategory)
        {
            _context.secondaryCategories.Add(secondaryCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecondaryCategory", new { id = secondaryCategory.Id }, secondaryCategory);
        }

        // DELETE: api/Secondary/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SecondaryCategory>> DeleteSecondaryCategory(int id)
        {
            var secondaryCategory = await _context.secondaryCategories.FindAsync(id);
            if (secondaryCategory == null)
            {
                return NotFound();
            }

            _context.secondaryCategories.Remove(secondaryCategory);
            await _context.SaveChangesAsync();

            return secondaryCategory;
        }

        private bool SecondaryCategoryExists(int id)
        {
            return _context.secondaryCategories.Any(e => e.Id == id);
        }
    }
}
