using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LinqJoinAppCore.Models
{
    public class Incentive
    {
        [Key]
        public int IncentiveId { get; set; }
        public int IncentiveAmount { get; set; }
    }
}
