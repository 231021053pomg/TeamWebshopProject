using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }

        public Basket Basket { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
