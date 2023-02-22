using FoodDelivery.Dtos.FoodOrder;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Interfaces
{
    public interface IFoodOrderService
    {
        bool Create(FoodOrderCreateDto obj);
        Task<bool> Delete(int id);
        bool Update(FoodOrderUpdateDto obj);        
        Task<FoodOrderReadDto> GetById(int id);
    }
}