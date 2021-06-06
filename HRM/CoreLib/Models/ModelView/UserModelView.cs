using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models.ModelView
{
    public class UserModelView
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string EmpCode { get; set; }

        public bool? ClientStatus { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string GroupCode { get; set; }
    }
}
