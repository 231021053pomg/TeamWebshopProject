using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Login Login { get; set; }

        [Required]
        public Credit Credit { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Username can not be longer than 20 characters")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "FirstName can not be longer than 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "LastName can not be longer than 20 characters")]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Address can not be longer than 64 characters")]
        public string AddressStreet { get; set; }

        [Required]
        public int AdressNumber { get; set; }

        [Required]
        public int AddressPostCode { get; set; }

    }
}
