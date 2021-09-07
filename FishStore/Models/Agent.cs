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
        [Required(ErrorMessage = "Please enter the agent name")]
        [StringLength(10)]
        [Display(Name = "Agent Name")]
        public string AgentName { get; set; }
        [Required(ErrorMessage = "Please enter the agent phone")]
        [Display(Name = "Phone Number")]
        public int Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }



    }
}
