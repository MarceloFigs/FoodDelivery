using FoodDelivery.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace FoodDelivery.Dtos.FoodOrder
{
    public class FoodOrderUpdateDto
    {
        public int Id { get; set; }
        public int CustomerAddressId { get; set; }
        public int OrderStatusId { get; set; }
        public int AssignedDriverID { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DeliverDateTime { get; set; }
        public int DriverRating { get; set; }
        public int RestaurantRating { get; set; }
    }
}
