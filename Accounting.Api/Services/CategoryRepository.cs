using Accounting.Api.DbContexts;
using Accounting.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AccountingDbContext _context;

        public CategoryRepository(AccountingDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddPrimaryCategory(PrimaryCategory primaryCategory)
        {
            _context.PrimaryCategories.Add(primaryCategory);
        }

        public void DeletePrimaryCategory(PrimaryCategory primaryCategory)
        {
            _context.PrimaryCategories.Remove(primaryCategory);
        }

     

        public async Task<IEnumerable<PrimaryCategory>> GetAllPrimaryCategoryAsync()
        {
            return await _context.PrimaryCategories.ToListAsync();
        }

        public async Task<PrimaryCategory> GetPrimaryCategoryAsync(int primaryId)
        {
            return await _context.PrimaryCategories.FirstOrDefaultAsync(p => p.Id == primaryId);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public void UpdatePrimaryCategory(PrimaryCategory primaryCategory)
        {
            _context.Update(primaryCategory);
        }
    }
}
