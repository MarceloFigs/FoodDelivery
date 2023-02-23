using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Dtos.MenuItem
{
    public class MenuItemCreateDto
    {
        [Required(ErrorMessage = "Field ItemName is necessary")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Price is necessary")]
        public decimal Price { get; set; }
        public int MenuItemCategoryId { get; set; }
        public int RestaurantId { get; set; }
    }
}
