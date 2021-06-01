using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Item
    {
        public Item()
        {
            Tags = new();
        }

        [Key]
        public int Id { get; set; }

        public string ItemType { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public string Discription { set; get; }

        public string Image { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
