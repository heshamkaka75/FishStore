using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public class Fish
    {
        [Key]
        public int FishID { get; set; }
        [Required(ErrorMessage = "Please enter the fish name")]
        [StringLength(10)]
        [Display(Name = "Fish Name")]
        public string FishName { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
