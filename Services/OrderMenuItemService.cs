using AutoMapper;
using FoodDelivery.Data.Repository.Interfaces;
using FoodDelivery.Dtos.OrderMenuItemDto;
using FoodDelivery.Models;
using FoodDelivery.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.Services
{
    public class OrderMenuItemService : IOrderMenuItemService
    {
        private readonly IOrderMenuItemRepository _orderMenuItemRepository;
        private readonly IMapper _mapper;
        public OrderMenuItemService(IOrderMenuItemRepository orderMenuItemRepository, IMapper mapper)
        {
            _orderMenuItemRepository = orderMenuItemRepository;
            _mapper = mapper;
        }

        public bool Create(OrderMenuItemCreateDto obj)
        {
            var orderMenuItem = _mapper.Map<OrderMenuItem>(obj);
            return _orderMenuItemRepository.Create(orderMenuItem);
        }

        public async Task<bool> Delete(int id)
        {
            var orderMenuItem = await _orderMenuItemRepository.GetById(id);
            if (orderMenuItem is null) return false;
            return _orderMenuItemRepository.Delete(orderMenuItem);
        }

        public async Task<OrderMenuItemReadDto> GetById(int id)
        {
            var orderMenuItem = await _orderMenuItemRepository.GetById(id);
            return _mapper.Map<OrderMenuItemReadDto>(orderMenuItem);
        }

        public async Task<IEnumerable<OrderMenuItemReadDto>> GetOrderMenuItemsByFoodOrderId(int id)
        {
            var orderMenuItem = await _orderMenuItemRepository.GetOrderMenuItemsByFoodOrderId(id);
            return _mapper.Map<IEnumerable<OrderMenuItemReadDto>>(orderMenuItem);
        }

        public bool Update(OrderMenuItemUpdateDto obj)
        {
            var orderMenuItem = _mapper.Map<OrderMenuItem>(obj);
            return _orderMenuItemRepository.Update(orderMenuItem);
        }
    }
}
