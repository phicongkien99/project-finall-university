using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        
        public string PassWord { get; set; }

        public string RoleCode { get; set; }
    }
}
