using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public class Boat
    {
        [Key]
        public int BoatId { get; set; }
        [Required(ErrorMessage = "Please enter the boat name")]
        [StringLength(10)]
        [Display(Name = "Boat Name")]
        public string BoatName { get; set; }
        [Required(ErrorMessage = "Please enter the manger name")]
        [Display(Name = "Manger Name")]
        public string Manger { get; set; }
        [Required(ErrorMessage = "Please enter the manger phone")]
        [Display(Name = "Phone Number")]
        public int Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
