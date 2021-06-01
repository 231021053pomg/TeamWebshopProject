using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }

        public Order Order { get; set; }

        public string Status { get; set; }

    }
}
