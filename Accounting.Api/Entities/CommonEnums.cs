using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Entities
{
    public enum RecordType
    {
        Income = 0,
        Expense = 1
    }

    public enum QueryType
    {
        Month = 0,
        Last3Month = 1,
        Year = 2
    }
}
