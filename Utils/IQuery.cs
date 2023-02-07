using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.Utils
{
    public interface IQuery<T>
    {
        Task<T> GetById(int id);
    }
}
