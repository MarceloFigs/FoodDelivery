using FoodDelivery.DataDb.Repository.Interfaces;
using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.DataDb.Repository
{
    public class MenuItemCategoryRepository : IMenuItemCategoryRepository
    {
        private readonly FoodDeliveryDbContext _context;
        public MenuItemCategoryRepository(FoodDeliveryDbContext context)
        {
            _context = context;
        }

        public bool Create(MenuItemCategory obj)
        {
            _context.MenuItemCategory.Add(obj);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(MenuItemCategory obj)
        {
            _context.MenuItemCategory.Remove(obj);
            return _context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<MenuItemCategory>> GetAll()
        {
            return await _context.MenuItemCategory.ToListAsync();
        }
        public async Task<MenuItemCategory> GetById(int id)
        {
            return await _context.MenuItemCategory
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Update(MenuItemCategory obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            var result = _context.SaveChanges() > 0;
            _context.Entry(obj).State = EntityState.Detached;

            return result;
        }
    }
}
