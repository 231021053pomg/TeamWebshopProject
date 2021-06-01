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

        public string AccessType { get; set; }

        public string Email { set; get; }

        public string Password { get; set; }

    }
}
