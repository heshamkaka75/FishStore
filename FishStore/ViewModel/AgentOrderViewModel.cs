using FishStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.ViewModel
{
    public class AgentOrderViewModel
    {

        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please enter the agent name")]
        [Display(Name = "Agent Name")]
        public int AgentNo { get; set; }
        [ForeignKey("AgentNo")]
        public List<Agent> Agent { get; set; }
        [Required(ErrorMessage = "Please enter the fish type")]
        [Display(Name = "Fish Type")]
        public Fish FishNo { get; set; }
        [ForeignKey("FishNo")]
        public List<Fish> Fish { get; set; }
        [Required(ErrorMessage = "Please enter the fish wight")]
        [Display(Name = "Fish Wight")]
        public int Weight { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Please select status of order")]
        [Display(Name = "Order Status")]
        public int OrderStatus { get; set; }
    }
}
