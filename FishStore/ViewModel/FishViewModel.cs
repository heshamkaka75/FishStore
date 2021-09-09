using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FishStore.ViewModel
{
    public class FishViewModel
    {
        

        public int FishID { get; set; }
        [Required(ErrorMessage = "Please enter the fish name")]
        [StringLength(10)]
        [Display(Name = "Fish Name")]
        public string FishName { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Image")]
        [Required, FileExtensions(Extensions = (".jpg,.jpeg,.png"), ErrorMessage = "Your image's filetype is not valid.")]
        public IFormFile ImageFile { get; set; }
    }
}
