using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodDelivery.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; private set; }

        [JsonIgnore]
        public IEnumerable<MenuItem> MenuItem { get; private set; }
    }
}
