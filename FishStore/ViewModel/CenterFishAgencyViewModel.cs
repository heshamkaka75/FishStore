using FishStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.ViewModel
{
    public class CenterFishAgencyViewModel
    {
        public int CFA_id { get; set; }
        [Required(ErrorMessage = "Please enter the fish wight")]
        [Display(Name = "Wight")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Please enter the fish type")]
        [Display(Name = "Fish Type")]
        public int FishNo { get; set; }
        [ForeignKey("FishNo")]
        public List<Fish> Fish { get; set; }
        [Required(ErrorMessage = "Please enter the Boate type")]
        [Display(Name = "Boat Type")]
        public int BoatNo { get; set; }
        [ForeignKey("BoatNo")]
        public List<Boat> Boat { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; }
    }
}

