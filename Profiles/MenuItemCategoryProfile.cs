using AutoMapper;
using FoodDelivery.Dtos.MenuItemCategoryDto;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
    public class MenuItemCategoryProfile : Profile
    {
        public MenuItemCategoryProfile()
        {
            CreateMap<MenuItemCategory, MenuItemCategoryReadDto>();
        }
    }
}
