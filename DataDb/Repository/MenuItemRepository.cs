using FoodDelivery.DataDb.Repository.Interfaces;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.DataDb.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly FoodDeliveryDbContext _context;
        public MenuItemRepository(FoodDeliveryDbContext context)
        {
            _context = context;
        }

        public bool Create(MenuItem obj)
        {
            _context.MenuItem.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(MenuItem obj)
        {
            _context.MenuItem.Remove(obj);
            return _context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<MenuItem>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsByCategoryId(int menuCategoryId)
        {
            var result = await _context.MenuItem
                .Include(x => x.MenuItemCategory)
                .Include(x => x.Restaurant)
                .Where(x => x.MenuItemCategoryId == menuCategoryId)
                .ToListAsync();

            return result;
        }

        public async Task<MenuItem> GetById(int id)
        {
            return await _context.MenuItem
                .Include(x => x.MenuItemCategory)
                .Include(x => x.Restaurant)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public bool Update(MenuItem obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            var result = _context.SaveChanges() > 0;
            _context.Entry(obj).State = EntityState.Detached;

            return result;
        }
    }
}
