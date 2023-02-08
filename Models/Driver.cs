using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
