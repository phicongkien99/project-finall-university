using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models
{
    public class Contract
    {
        public int ID { get; set; }

        public string EmpCode { get; set; }

        public string ContractType { get; set; }

        public string ContractNumber { get; set; }

        public DateTime EffecttiveDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public DateTime SignDate { get; set; }

        public string SignEmp { get; set; }

        public string ManageEmp { get; set; }
    }
}
