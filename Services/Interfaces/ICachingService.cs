using System.Threading.Tasks;

namespace FoodDelivery.Services.Interfaces
{
    public interface ICachingService
    {
        Task SetAsync(string key, string value);
        Task<string> GetAsync(string key);
    }
}
