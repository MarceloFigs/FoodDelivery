using FoodDelivery.Dtos.MenuItemCategoryDto;
using FoodDelivery.Dtos.Restaurant;
using FoodDelivery.Models;

namespace FoodDelivery.Dtos.MenuItem
{
    public class MenuItemReadDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public MenuItemCategoryReadDto MenuItemCategory { get; private set; }        
        public RestaurantReadDto Restaurant { get; private set; }
    }
}
