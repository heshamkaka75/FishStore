using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public class AgentOrder
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please enter the agent name")]
        [Display(Name = "Agent Name")]
        public int AgentNo { get; set; }
        [ForeignKey("AgentNo")]
        public Agent Agent { get; set; }
        [Required(ErrorMessage = "Please enter the fish type")]
        [Display(Name = "Fish Type")]
        public int FishNo { get; set; }
        [ForeignKey("FishNo")]
        public Fish Fish { get; set; }
        [Required(ErrorMessage = "Please enter the fish wight")]
        [Display(Name = "Fish Wight")]
        public int Weight { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Please select status of order")]
        [Display(Name = "Order Status")]
        public int OrderStatus { get; set; }
    }
}
