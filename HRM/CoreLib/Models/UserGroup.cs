using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models
{
    public class UserGroup
    {
        public string Username { get; set; }

        public string GroupCode { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateOn { get; set; }
    }
}
