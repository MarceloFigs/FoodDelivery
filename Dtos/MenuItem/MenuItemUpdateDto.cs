using FoodDelivery.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Dtos.MenuItem
{
    public class MenuItemUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field ItemName is necessary")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Price is necessary")]
        public decimal Price { get; set; } 
        public int MenuItemCategoryId { get; set; }
        public int RestaurantId { get; set; }
    }
}
