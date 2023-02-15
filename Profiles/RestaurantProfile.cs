using AutoMapper;
using FoodDelivery.Dtos.Restaurant;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantReadDto>();
        }
    }
}
