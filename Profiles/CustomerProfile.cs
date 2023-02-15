using AutoMapper;
using FoodDelivery.Dtos.Customer;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
        }
    }
}
