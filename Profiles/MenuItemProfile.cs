using AutoMapper;
using FoodDelivery.Dtos.MenuItem;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuItemCreateDto, MenuItem>();
            CreateMap<MenuItem, MenuItemReadDto>();
            CreateMap<MenuItemUpdateDto, MenuItem>();
        }
    }
}
