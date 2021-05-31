﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Merch : ProductModel
    {
        [Required]
        public decimal Weight { get; set; }

        [Required]
        public decimal Volume { get; set; }
    }
}
