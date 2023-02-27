using FoodDelivery.DataDb.Repository.Interfaces;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.DataDb.Repository
{
    public class OrderMenuItemRepository : IOrderMenuItemRepository
    {
        private readonly FoodDeliveryDbContext _context;
        public OrderMenuItemRepository(FoodDeliveryDbContext context)
        {
            _context = context;
        }

        public bool Create(OrderMenuItem obj)
        {
            _context.OrderMenuItem.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(OrderMenuItem obj)
        {
            _context.OrderMenuItem.Remove(obj);
            return _context.SaveChanges() > 0;
        }

        public Task<IEnumerable<OrderMenuItem>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<OrderMenuItem> GetById(int id)
        {
            return await _context.OrderMenuItem
                .Include(x => x.MenuItem)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Update(OrderMenuItem obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            var result = _context.SaveChanges() > 0;
            _context.Entry(obj).State = EntityState.Detached;

            return result;
        }
        public async Task<IEnumerable<OrderMenuItem>> GetOrderMenuItemsByFoodOrderId(int id)
        {
            return await _context.OrderMenuItem
                .Include(x => x.MenuItem)
                .Include(x => x.MenuItem.MenuItemCategory)
                .Where(x => x.FoodOrderId == id)
                .ToListAsync();
        }
    }
}
