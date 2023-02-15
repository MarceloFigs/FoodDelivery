using FoodDelivery.Dtos.FoodOrder;
using FoodDelivery.Dtos.MenuItem;
using FoodDelivery.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Interfaces
{
    public interface IMenuItemService
    {
        bool Create(MenuItemCreateDto obj);
        Task<bool> Delete(int id);
        bool Update(MenuItemUpdateDto obj);
        Task<MenuItemReadDto> GetById(int id);
        Task<IEnumerable<MenuItemReadDto>> GetAllMenuItemsByCategoryId(int menuItemCategoryId);
    }
}
