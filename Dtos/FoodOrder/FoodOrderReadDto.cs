using FoodDelivery.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using FoodDelivery.Dtos.CustomerAddress;
using FoodDelivery.Dtos.Restaurant;
using FoodDelivery.Dtos.Customer;
using FoodDelivery.Dtos.Driver;

namespace FoodDelivery.Dtos.FoodOrder
{
    public class FoodOrderReadDto
    {
        public int Id { get; set; }
        public CustomerReadDto Customer { get; private set; }
        public RestaurantReadDto Restaurant { get; private set; }
        public CustomerAddressReadDto CustomerAddress { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public DriverReadDto Driver { get; private set; }

        public DateTime OrderDateTime { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DeliverDateTime { get; set; }
        public int DriverRating { get; set; }
        public int RestaurantRating { get; set; }
    }
}
