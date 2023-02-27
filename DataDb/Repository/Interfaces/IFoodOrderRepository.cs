using FoodDelivery.Models;
using FoodDelivery.Utils;

namespace FoodDelivery.DataDb.Repository.Interfaces
{
    public interface IFoodOrderRepository : ICommand<FoodOrder>, IQuery<FoodOrder>
    {
    }
}
