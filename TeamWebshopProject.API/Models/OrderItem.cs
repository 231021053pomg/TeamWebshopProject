using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public Order Order { get; set; }

        public Item Item { get; set; }

        public decimal Quantity { get; set; }
    }
}
