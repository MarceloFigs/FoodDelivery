using System;
using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Dtos.FoodOrder
{
    public class FoodOrderCreateDto
    {
        [Required(ErrorMessage = "Missing customer id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Missing restaurant id")]
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "Missing customer address id")]
        public int CustomerAddressId { get; set; }

        [Required(ErrorMessage = "Missing order status id")]
        public int OrderStatusId { get; set; }

        [Required(ErrorMessage = "Missing driver id")]
        public int AssignedDriverID { get; set; }

        public DateTime OrderDateTime { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DeliverDateTime { get; set; }
        public int DriverRating { get; set; }
        public int RestaurantRating { get; set; }
    }
}
