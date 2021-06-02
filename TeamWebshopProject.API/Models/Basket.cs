using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TeamWebshopProject.API.Models
{
    public class Basket : BaseModel
    {
        [Required]
        public Customer Customer { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public DateTime Created { get; set; }
    }
}
