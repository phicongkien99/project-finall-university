using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models
{
    public class Department
    {
        public int ID { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

        public int Order { get; set; }

        public bool Status { get; set; }

        public string Location { get; set; }

        public string Note { get; set; }
    }
}
