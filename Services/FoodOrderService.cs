using AutoMapper;
using FoodDelivery.Data.Repository.Interfaces;
using FoodDelivery.Dtos.FoodOrder;
using FoodDelivery.Models;
using FoodDelivery.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.Services
{
    public class FoodOrderService : IFoodOrderService
    {
        private readonly IFoodOrderRepository _foodOrderRepository;
        private readonly IMapper _mapper;
        public FoodOrderService(IFoodOrderRepository foodOrderRepository, IMapper mapper)
        {
            _foodOrderRepository = foodOrderRepository;
            _mapper = mapper;
        }

        public bool Create(FoodOrderCreateDto obj)
        {
            var foodOrder = _mapper.Map<FoodOrder>(obj);
            return _foodOrderRepository.Create(foodOrder);
        }

        public async Task<bool> Delete(int id)
        {
            var foodOrder = await _foodOrderRepository.GetById(id);
            if (foodOrder is null) return false;
            return _foodOrderRepository.Delete(foodOrder);
        }

        public bool Update(FoodOrderUpdateDto obj)
        {
            var foodOrder = _mapper.Map<FoodOrder>(obj);
            return _foodOrderRepository.Update(foodOrder);
        }

        public Task<IEnumerable<FoodOrderReadDto>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<FoodOrderReadDto> GetById(int id)
        {
            var foodOrder = await _foodOrderRepository.GetById(id);            
            return _mapper.Map<FoodOrderReadDto>(foodOrder);
        }
    }
}
