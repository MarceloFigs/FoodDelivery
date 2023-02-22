using AutoMapper;
using FoodDelivery.Dtos.FoodOrder;
using FoodDelivery.Dtos.OrderMenuItemDto;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
    public class OrderMenuItemProfile : Profile
    {
        public OrderMenuItemProfile() 
        {
            CreateMap<OrderMenuItemCreateDto, OrderMenuItem>();
            CreateMap<OrderMenuItem, OrderMenuItemReadDto>();
            CreateMap<OrderMenuItemUpdateDto, OrderMenuItem>();
        }
    }
}
