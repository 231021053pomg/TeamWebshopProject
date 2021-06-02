using System.ComponentModel.DataAnnotations;

namespace TeamWebshopProject.API.Models
{
    public class Login : BaseModel
    {
        [Required]
        public string AccessType { get; set; }

        [Required]
        public string Email { set; get; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or more")]
        public string Password { get; set; }

    }
}
