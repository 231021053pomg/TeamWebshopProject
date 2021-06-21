using System.ComponentModel.DataAnnotations;

namespace TeamWebshopProject.API.Models
{
    public class Delivery : BaseModel
    {
        [Required]
        public Order Order { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "Status message can not be longer than 128 characters")]
        public string Status { get; set; }

    }
}
