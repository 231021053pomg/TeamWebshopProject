using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string TypeIdentity { get; set; }
    }
}
