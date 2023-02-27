using FoodDelivery.Models;
using FoodDelivery.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.DataDb.Repository.Interfaces
{
    public interface IOrderMenuItemRepository : ICommand<OrderMenuItem>, IQuery<OrderMenuItem>
    {
        Task<IEnumerable<OrderMenuItem>> GetOrderMenuItemsByFoodOrderId(int id);
    }
}
