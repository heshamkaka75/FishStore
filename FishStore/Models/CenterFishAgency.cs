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

        public int Weight { get; set; }
        public int FishNo { get; set; }
        [ForeignKey("FishNo")]
        public Fish Fish { get; set; }

        public Boat Boat { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
