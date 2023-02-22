namespace FoodDelivery.Dtos.OrderMenuItemDto
{
    public class OrderMenuItemCreateDto
    {
        public int FoodOrderId { get; set; }
        public int MenuItemId { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
