using System.ComponentModel.DataAnnotations;

namespace TeamWebshopProject.API.Models
{
    public class Tag : BaseModel
    {
        [Required]
        public string Name { get; set; }

    }
}
