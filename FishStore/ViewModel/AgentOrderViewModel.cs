using FishStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.ViewModel
{
    public class AgentOrderViewModel
    {
        public int OrderId { get; set; }
        public Agent AgentNo { get; set; }
        public List<Agent> Agent { get; set; }
        public Fish FishNo { get; set; }
        public List<Fish> Fish { get; set; }
        public int Weight { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
    }
}
