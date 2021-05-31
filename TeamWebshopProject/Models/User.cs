using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class User : BaseModel
    {
        [Required]
        public UserType Type { get; set; }

        public int AdressId { get; set; }


    }
}
