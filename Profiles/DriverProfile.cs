using AutoMapper;
using FoodDelivery.Dtos.Driver;
using FoodDelivery.Models;

namespace FoodDelivery.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverReadDto>();
        }
    }
}
