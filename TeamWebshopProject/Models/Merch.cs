using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class Merch : ProductModel
    {
        public decimal Weight { get; set; }

        public decimal Volume { get; set; }
    }
}
