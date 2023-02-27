using FoodDelivery.Dtos.MenuItemCategoryDto;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Interfaces
{
    public interface IMenuItemCategoryService
    {
        bool Create(MenuItemCategoryCreateDto obj);
        Task<bool> Delete(int id);
        bool Update(MenuItemCategoryUpdateDto obj);
        Task<MenuItemCategoryReadDto> GetById(int id);
    }
}
