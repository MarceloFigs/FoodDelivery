using AutoMapper;
using FoodDelivery.Data.Repository.Interfaces;
using FoodDelivery.Dtos.MenuItem;
using FoodDelivery.Models;
using FoodDelivery.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;
        public MenuItemService(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        public bool Create(MenuItemCreateDto obj)
        {
            var menuItem = _mapper.Map<MenuItem>(obj);
            return _menuItemRepository.Create(menuItem);
        }

        public async Task<bool> Delete(int id)
        {
            var menuItem = await _menuItemRepository.GetById(id);
            if (menuItem is null) return false;

            return _menuItemRepository.Delete(menuItem);
        }

        public async Task<IEnumerable<MenuItemReadDto>> GetAllMenuItemsByCategoryId(int menuItemCategoryId)
        {
            var menuItem = await _menuItemRepository.GetAllMenuItemsByCategoryId(menuItemCategoryId);
            return _mapper.Map<IEnumerable<MenuItemReadDto>>(menuItem);
        }

        public async Task<MenuItemReadDto> GetById(int id)
        {
            var menuItem = await _menuItemRepository.GetById(id);
            return _mapper.Map<MenuItemReadDto>(menuItem);
        }

        public bool Update(MenuItemUpdateDto obj)
        {
            var menuItem = _mapper.Map<MenuItem>(obj);
            return _menuItemRepository.Update(menuItem);
        }


    }
}
