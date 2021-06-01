using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AccessType { get; set; }

        [Required]
        public string Email { set; get; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or more")]  
        public string Password { get; set; }

    }
}
