using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field ItemName is necessary")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Price is necessary")]
        public decimal Price { get; set; }

        [ForeignKey("MenuItemCategory")]
        public int MenuItemCategoryId { get; set; }
        public virtual MenuItemCategory MenuItemCategory { get; private set; }
    }
}
