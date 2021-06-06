using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models
{
    public class Employee
    {
        public int? ID { get; set; }

        public string EmpCode { get; set; }

        public DateTime? BOD { get; set; }

        public bool? Sex { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string DepartmentCode { get; set; }

        public string OfficeTile { get; set; }

        public string OfficePosition { get; set; }

        public string TaxNameber { get; set; }

        public bool? EmpStatus { get; set; }

        public DateTime? ActiveDate { get; set; }

        public string EduLevel { get; set; }

        public string PassportNumber { get; set; }

        public DateTime? PassportDate { get; set; }

        public string PassportPlace { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public string OrtheInfo { get; set; }

        public int? VacationNumber { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
