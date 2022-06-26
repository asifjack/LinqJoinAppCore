using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinqJoinAppCore.Models
{
    public class ViewModel
    {
        public Employee employee { get; set; }
        public Department department { get; set; }
        public Incentive incentive { get; set; }
    }
}
