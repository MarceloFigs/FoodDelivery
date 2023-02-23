using AutoMapper;
using FoodDelivery.Dtos.CustomerAddress;
using FoodDelivery.Dtos.FoodOrder;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
    public class CustomerAddressProfile : Profile
    {
        public CustomerAddressProfile()
        {
            CreateMap<CustomerAddress, CustomerAddressReadDto>();
        }
    }
}
