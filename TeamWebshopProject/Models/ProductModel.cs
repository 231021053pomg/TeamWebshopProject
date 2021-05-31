using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class ProductModel : BaseModel
    {
        public ProductModel()
        {
            Tags = new();
        }

        public string Title { get; set; }

        public byte[] Image { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
