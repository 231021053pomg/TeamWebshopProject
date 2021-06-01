using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Credit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public int? CreditAmount { get; set; }
    }
}
