using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodDelivery.Models
{
    public class MenuItemCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field name is necessary")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<MenuItem> MenuItem { get; private set; }
    }
}
