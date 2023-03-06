using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Models.Core
{
    public class ErrorResult
    {
        public string Source { get; set; }
        public string Exception { get; set; }
        public string ErrorId { get; set; }
        public int StatusCode { get; set; }
    }
}
