using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Entities
{
    public class Record
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public Subject Subject { get; set; }

        public decimal Amount { get; set; }

        
    }
}
