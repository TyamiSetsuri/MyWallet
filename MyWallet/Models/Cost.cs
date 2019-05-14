using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallet.Models
{
    public class Cost
    {
        [Key]
        public int CostNum { get; set; }
        public string Costs { get; set; }
        public string ItemName { get; internal set; }
        public int ItemId { get; internal set; }
    }
}
