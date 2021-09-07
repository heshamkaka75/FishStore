using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
