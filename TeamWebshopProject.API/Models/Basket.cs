using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public DateTime Created { get; set; }
    }
}
