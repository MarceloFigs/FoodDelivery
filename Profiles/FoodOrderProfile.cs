using AutoMapper;
using FoodDelivery.Dtos.FoodOrder;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
    public class FoodOrderProfile : Profile
    {
        public FoodOrderProfile() 
        {
            CreateMap<FoodOrderCreateDto, FoodOrder>();
            CreateMap<FoodOrder, FoodOrderReadDto>();
            CreateMap<FoodOrderUpdateDto, FoodOrder>();
        }
    }
}
