using FoodDelivery.Dtos.OrderMenuItemDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Interfaces
{
    public interface IOrderMenuItemService
    {
        bool Create(OrderMenuItemCreateDto obj);
        Task<bool> Delete(int id);
        bool Update(OrderMenuItemUpdateDto obj);
        Task<OrderMenuItemReadDto> GetById(int id);
        Task<IEnumerable<OrderMenuItemReadDto>> GetOrderMenuItemsByFoodOrderId(int id);
    }
}
