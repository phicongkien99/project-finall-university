using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models
{
    public class InsuranceSocial
    {
        public int? ID { get; set; }

        public string EmpCode { get; set; }

        public string FullName { get; set; }

        public string CodeNumber { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string FromDateStr { get; set; }

        public string ToDateStr { get; set; }

        public bool? Status { get; set; }

        public string Company { get; set; }

    }
}
