using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models.ViewModels
{
    public class UserViewModel
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

        public string Group { get; set; }
    }
}
