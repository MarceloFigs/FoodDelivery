using FoodDelivery.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FoodDelivery.Dtos.Address;

namespace FoodDelivery.Dtos.Restaurant
{
    public class RestaurantReadDto
    {
        public string Name { get; set; }
        public AddressReadDto Address { get; private set; }
    }
}
