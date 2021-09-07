using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public class AgentOrder
    {
        [Key]
        public int OrderId { get; set; }
        public Agent AgentNo { get; set; }
        public Fish FishNo { get; set; }
        public int Weight { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
    }
}
