namespace FoodDelivery.Dtos.OrderMenuItemDto
{
    public class OrderMenuItemUpdateDto
    {
        public int Id { get; set; }
        public int FoodOrderId { get; set; }
        public int MenuItemId { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
