using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Models
{
    public class Result<T> where T : class
    {              
        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public T Data { get; set; }
    }

}
