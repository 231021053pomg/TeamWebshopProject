using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public string ItemType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "Item description can not be more than 5000 chars")]
        public string Discription { set; get; }

        public string Image { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
