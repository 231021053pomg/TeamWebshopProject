using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TeamWebshopProject.API.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime? EditedAt { get; set; }

        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }
    }
}
