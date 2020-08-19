using Accounting.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<PrimaryCategory>> GetAllPrimaryCategoryAsync();
     
        //Task<IEnumerable<SecondaryCategory>> GetAllSecondaryCategoryAsync(int primaryId);

        Task<PrimaryCategory> GetPrimaryCategoryAsync(int primaryId);

        void AddPrimaryCategory(PrimaryCategory primaryCategory);

        void UpdatePrimaryCategory(PrimaryCategory primaryCategory);

        void DeletePrimaryCategory(PrimaryCategory primaryCategory);

        //Task<SecondaryCategory> GetSecondaryCategoryAsync(int secondaryId);

        Task<bool> SaveAsync();
    }
}
