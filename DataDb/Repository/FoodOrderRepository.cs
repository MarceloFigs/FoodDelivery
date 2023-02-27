using FoodDelivery.DataDb.Repository.Interfaces;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.DataDb.Repository
{
    public class FoodOrderRepository : IFoodOrderRepository
    {
        private readonly FoodDeliveryDbContext _context;
        public FoodOrderRepository(FoodDeliveryDbContext context)
        {
            _context = context;
        }

        public bool Create(FoodOrder obj)
        {
            _context.FoodOrder.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(FoodOrder obj)
        {
            _context.FoodOrder.Remove(obj);
            return _context.SaveChanges() > 0;
        }

        public Task<IEnumerable<FoodOrder>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<FoodOrder> GetById(int id)
        {
            return await _context.FoodOrder
                .Include(x => x.Customer)
                .Include(x => x.Restaurant).Include(x => x.Restaurant.Address)
                .Include(x => x.CustomerAddress).Include(x => x.CustomerAddress.Address)
                .Include(x => x.OrderStatus)
                .Include(x => x.Driver)                
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public bool Update(FoodOrder obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            var result = _context.SaveChanges() > 0;
            _context.Entry(obj).State = EntityState.Detached;

            return result;
        }
    }
}
