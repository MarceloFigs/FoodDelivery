using AutoMapper;
using FoodDelivery.Dtos.Address;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressReadDto>();
        }
    }
}
