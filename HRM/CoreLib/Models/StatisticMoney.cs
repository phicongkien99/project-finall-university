using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models
{
    public class StatisticMoney
    {
        public string EmpCode { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string DepartmentName { get; set; }

        public decimal TotalMoney { get; set; }

        public decimal TotalMoneyMonth { get; set; }

        public decimal TotalMoneyYear { get; set; }
    }
}
