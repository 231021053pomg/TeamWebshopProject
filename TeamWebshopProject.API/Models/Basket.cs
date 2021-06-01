using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime Created { get; set; }
    }
}
