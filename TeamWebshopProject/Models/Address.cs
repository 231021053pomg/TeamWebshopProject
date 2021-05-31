using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Address
    {
        [Required]
        public int PostCode { get; set; }

        [Required]
        [StringLength(32)]
        public string City { get; set; }

        [Required]
        [StringLength(32)]
        public string AdressLine1 { get; set; }

        [Required]
        [StringLength(32)]
        public string AdressLine2 { get; set; }
    }
}
