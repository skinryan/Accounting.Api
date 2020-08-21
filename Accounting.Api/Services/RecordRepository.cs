using Accounting.Api.DbContexts;
using Accounting.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Services
{
    public class RecordRepository : IRecordRepository
    {
        private readonly AccountingDbContext _context;

        public RecordRepository(AccountingDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddRecord(Record record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            _context.Records.Add(record);
        }

        public void DeleteRecord(Record record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            if (!Exists(record.Id))
            {
                throw new ArgumentOutOfRangeException(nameof(record.Id));
            }

            _context.Records.Remove(record);
        }

        public async Task<IEnumerable<Record>> GetRecordsAsync(DateTime date, QueryType type)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }

            var startDate = date.AddDays(-(date.Day - 1));

            switch (type)
            {
                case QueryType.Month:
                    return await _context.Records.Where(t => t.Date >= startDate && t.Date < date.AddMonths(1)).ToArrayAsync();
                case QueryType.Last3Month:
                    return await _context.Records.Where(t => t.Date >= startDate.AddMonths(-2)).ToArrayAsync();
                case QueryType.Year:
                    startDate = startDate.AddMonths(-(date.Month - 1));
                    return await _context.Records.Where(t => t.Date >= startDate).ToArrayAsync();
                default:
                    throw new ArgumentNullException(nameof(type));
            }
        }

        public async Task<Record> GetRecordsAsync(int id)
        {
            return await _context.Records.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 1;
        }

        public void UpdateRecord(Record record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            if (!Exists(record.Id))
            {
                throw new ArgumentException(nameof(record.Id));
            }

            _context.Records.Update(record);
        }

        private bool Exists(int recordId)
        {
            return _context.Records.Any(t => t.Id == recordId);
        }
    }
}
