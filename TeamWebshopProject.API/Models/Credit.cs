using System.ComponentModel.DataAnnotations.Schema;

namespace TeamWebshopProject.API.Models
{
    public class Credit : BaseModel
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal CreditAmount { get; set; }
    }
}
