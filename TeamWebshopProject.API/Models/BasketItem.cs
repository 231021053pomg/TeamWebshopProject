using System.ComponentModel.DataAnnotations;

namespace TeamWebshopProject.API.Models
{
    public class BasketItem : BaseModel
    {
        [Required]
        public Basket Basket { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
