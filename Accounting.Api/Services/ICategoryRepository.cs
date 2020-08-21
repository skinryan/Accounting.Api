using Accounting.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Services
{
    public interface ICategoryRepository
    {
        #region primary

        Task<IEnumerable<PrimaryCategory>> GetPrimaryCategoryAsync();
        Task<IEnumerable<PrimaryCategory>> GetPrimaryCategoryWithChildrenAsync();
        Task<PrimaryCategory> GetPrimaryCategoryAsync(int primaryId);
        void AddPrimaryCategory(PrimaryCategory primaryCategory);
        void UpdatePrimaryCategory(PrimaryCategory primaryCategory);
        void DeletePrimaryCategory(PrimaryCategory primaryCategory);

        #endregion

        #region secondary

        Task<IEnumerable<SecondaryCategory>> GetSecondaryCategorisAsync(int parentId);
        Task<SecondaryCategory> GetSecondaryCategoryAsync(int id);
        void AddSecondaryCategory(SecondaryCategory secondaryCategory);
        void UpdateSecondaryCategory(SecondaryCategory secondaryCategory);
        void DeleteSecondaryCategory(SecondaryCategory secondaryCategory);

        #endregion

        Task<bool> SaveAsync();
    }
}
