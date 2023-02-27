using FoodDelivery.Models;
using FoodDelivery.Utils;

namespace FoodDelivery.DataDb.Repository.Interfaces
{
    public interface IMenuItemCategoryRepository : ICommand<MenuItemCategory>, IQuery<MenuItemCategory>
    {
    }
}
