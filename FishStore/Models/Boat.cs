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
        public string BoatName { get; set; }
        public string Manger { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
