using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models
{
    public class TotalSalary
    {
        public int? ID { get; set; }

        public string EmpCode { get; set; }

        public double? TotalMoney { get; set; }

        public DateTime? Date { get; set; }
    }
}
