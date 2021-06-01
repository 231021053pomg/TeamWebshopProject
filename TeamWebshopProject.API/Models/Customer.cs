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

        public Login Login { get; set; }

        public Credit Credit { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public string AddressStreet { get; set; }

        public int AdressNumber { get; set; }

        public int AddressPostCode { get; set; }

    }
}
