﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
