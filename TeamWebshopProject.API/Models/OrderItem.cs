using System.ComponentModel.DataAnnotations;

namespace TeamWebshopProject.API.Models
{
    public class OrderItem : BaseModel
    {
        [Required]
        public Order Order { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
