﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Entities
{
    public class PrimaryCategory
    {
        [Key]
        public int Id { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public ICollection<SecondaryCategory> SecondaryCategory { get; set; }
    }
}
