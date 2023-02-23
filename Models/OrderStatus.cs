using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodDelivery.Models
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
