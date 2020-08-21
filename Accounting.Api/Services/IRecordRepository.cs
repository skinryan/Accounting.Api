using Accounting.Api.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Services
{
    public interface IRecordRepository
    {
        Task<IEnumerable<Record>> GetRecordsAsync(DateTime date, QueryType type);
        Task<Record> GetRecordsAsync(int id);
        void AddRecord(Record record);
        void UpdateRecord(Record record);
        void DeleteRecord(Record record);
        Task<bool> SaveAsync();
    }
}
