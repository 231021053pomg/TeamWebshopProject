using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Meme : ProductModel
    {
        [Required]
        public int PixelHeight { get; set; }

        [Required]
        public int PixelLenght { get; set; }
    }
}
