using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Models
{
    public class Bonus
    {
        public int? ID { get; set; }

        public string EmpCode { get; set; }

        public string Type { get; set; }

        public double Money { get; set; }

        public string Note { get; set; }

        public string RewardType { get; set; }

        public string FullName { get; set; }
    }
}
