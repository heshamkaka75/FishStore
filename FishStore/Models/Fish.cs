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
        public string FishName { get; set; }
        public string ImageUrl { get; set; }
    }
}
