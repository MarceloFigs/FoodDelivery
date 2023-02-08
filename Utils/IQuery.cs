using System.Threading.Tasks;

namespace FoodDelivery.Utils
{
    public interface IQuery<T>
    {
        Task<T> GetById(int id);
    }
}
