using FishStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.ViewModel
{
    public class CenterFishAgencyViewModel
    {
        public int CFA_id { get; set; }
        public int Weight { get; set; }
        public int FishNo { get; set; }
        public List<Fish> Fish { get; set; }
        public int BoatNo { get; set; }
        public List<Boat> Boat { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
