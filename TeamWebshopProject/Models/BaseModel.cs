using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeamWebshopProject.API.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime DeletedAt { get; set; }

        [JsonIgnore]
        public DateTime EditedAt { get; set; }
    }
}
