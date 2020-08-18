using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Entities
{
    public class Record
    {
        [Key]
        public long Id { get; set; }

        public RecordType Type { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public decimal Amount { get; set; }

        public int SecondaryId { get; set; }

        public SecondaryCategory Category { get; set; }

    }
}
