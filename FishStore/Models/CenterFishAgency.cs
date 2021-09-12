using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public class CenterFishAgency
    {
        [Key]
        public int CFA_id { get; set; }
        [Required(ErrorMessage = "Please enter the fish wight")]
        [Display(Name = "Wight")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Please enter the fish type")]
        [Display(Name = "Fish Type")]
        public int FishNo { get; set; }
        [ForeignKey("FishNo")]
        public Fish Fish { get; set; }
        [Required(ErrorMessage = "Please enter the Boate type")]
        [Display(Name = "Boat Type")]
        public int BoatNo { get; set; }
        [ForeignKey("BoatNo")]
        public Boat Boat { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false,DataFormatString ="{0:dd/MM/yyyy}")]
        [Display(Name = "Delivery Date")]
        
        public DateTime DeliveryDate { get; set; }
    }
}
