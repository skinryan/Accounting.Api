using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Entities
{
    public class SecondaryCategory
    {
        [Key]
        public int Id { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public int PrimaryId { get; set; }

        [JsonIgnore]
        public PrimaryCategory PrimaryCategory { get; set; }
    }
}
