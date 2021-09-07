using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.ViewModel
{
    public class FishViewModel
    {
        public int FishID { get; set; }
        public string FishName { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
