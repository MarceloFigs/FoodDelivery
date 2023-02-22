using FoodDelivery.Dtos.FoodOrder;
using FoodDelivery.Dtos.MenuItem;

namespace FoodDelivery.Dtos.OrderMenuItemDto
{
    public class OrderMenuItemReadDto
    {
        public int Id { get; set; }
        public int FoodOrderId { get; set; }
        public MenuItemReadDto MenuItem { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
