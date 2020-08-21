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

        #region Primary

        public void AddPrimaryCategory(PrimaryCategory primaryCategory)
        {
            if (primaryCategory == null)
            {
                throw new ArgumentNullException(nameof(primaryCategory));
            }

            _context.PrimaryCategories.Add(primaryCategory);
        }

        public void DeletePrimaryCategory(PrimaryCategory primaryCategory)
        {
            if (primaryCategory == null)
            {
                throw new ArgumentNullException(nameof(primaryCategory));
            }

            _context.PrimaryCategories.Remove(primaryCategory);
        }

        public void UpdatePrimaryCategory(PrimaryCategory primaryCategory)
        {
            if (primaryCategory == null)
            {
                throw new ArgumentNullException(nameof(primaryCategory));
            }

            if (!PrimaryExists(primaryCategory.Id))
            {
                throw new ArgumentException(nameof(primaryCategory.Id));
            }

            _context.PrimaryCategories.Update(primaryCategory);
        }

        public async Task<IEnumerable<PrimaryCategory>> GetPrimaryCategoryAsync()
        {
            return await _context.PrimaryCategories.ToListAsync();
        }

        public async Task<PrimaryCategory> GetPrimaryCategoryAsync(int primaryId)
        {
            return await _context.PrimaryCategories.FirstOrDefaultAsync(p => p.Id == primaryId);
        }

        public async Task<IEnumerable<PrimaryCategory>> GetPrimaryCategoryWithChildrenAsync()
        {
            return await _context.PrimaryCategories.Include(t => t.SecondaryCategory).ToListAsync();
        }

        #endregion

        #region Primary

        public void AddSecondaryCategory(SecondaryCategory secondaryCategory)
        {
            if (secondaryCategory == null)
            {
                throw new ArgumentNullException(nameof(secondaryCategory));
            }

            _context.secondaryCategories.Add(secondaryCategory);
        }

        public void DeleteSecondaryCategory(SecondaryCategory secondaryCategory)
        {
            if (secondaryCategory == null)
            {
                throw new ArgumentNullException(nameof(secondaryCategory));
            }

            _context.secondaryCategories.Remove(secondaryCategory);
        }

        public void UpdateSecondaryCategory(SecondaryCategory secondaryCategory)
        {
            if (secondaryCategory == null)
            {
                throw new ArgumentNullException(nameof(secondaryCategory));
            }

            if (!SecondaryExists(secondaryCategory.Id))
            {
                throw new ArgumentException(nameof(secondaryCategory.Id));
            }

            _context.secondaryCategories.Update(secondaryCategory);
        }

        public async Task<IEnumerable<SecondaryCategory>> GetSecondaryCategorisAsync(int parentId)
        {
            if (!PrimaryExists(parentId))
            {
                throw new ArgumentException(nameof(parentId));
            }

            return await _context.secondaryCategories.Where(t => t.PrimaryId == parentId).ToArrayAsync();
        }

        public async Task<SecondaryCategory> GetSecondaryCategoryAsync(int id)
        {
            if (!SecondaryExists(id))
            {
                throw new ArgumentException(nameof(id));
            }

            return await _context.secondaryCategories.SingleOrDefaultAsync(t => t.Id == id);
        }




        #endregion

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        private bool PrimaryExists(int primaryId)
        {
            return _context.PrimaryCategories.Any(t => t.Id == primaryId);
        }

        private bool SecondaryExists(int secondaryId)
        {
            return _context.secondaryCategories.Any(t => t.Id == secondaryId);
        }
    }
}
