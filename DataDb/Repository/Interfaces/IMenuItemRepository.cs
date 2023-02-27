using FoodDelivery.Models;
using FoodDelivery.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.DataDb.Repository.Interfaces
{
    public interface IMenuItemRepository : ICommand<MenuItem>, IQuery<MenuItem>
    {
        Task<IEnumerable<MenuItem>> GetAllMenuItemsByCategoryId(int id);
    }
}
