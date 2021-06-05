using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models
{
    public class CResult
    {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public object Data { get; set; }
    }
}
