using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.Utils
{
    public interface ICommand<T>
    {
        bool Create(T obj);
        bool Delete(T obj);
        bool Update(T obj);
        Task<IEnumerable<T>> GetAll();
    }
}
