using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
    [NotMapped]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field name is necessary")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
