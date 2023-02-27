using AutoMapper;
using FoodDelivery.DataDb.Repository.Interfaces;
using FoodDelivery.Dtos.MenuItemCategoryDto;
using FoodDelivery.Models;
using FoodDelivery.Services.Interfaces;
using System.Threading.Tasks;

namespace FoodDelivery.Services
{
    public class MenuItemCategoryService : IMenuItemCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMenuItemCategoryRepository _menuItemCategoryRepository;

        public MenuItemCategoryService(IMapper mapper, IMenuItemCategoryRepository menuItemCategoryRepository)
        {
            _mapper = mapper;
            _menuItemCategoryRepository = menuItemCategoryRepository;
        }

        public bool Create(MenuItemCategoryCreateDto obj)
        {
            var menuItemCategory = _mapper.Map<MenuItemCategory>(obj);
            return _menuItemCategoryRepository.Create(menuItemCategory);
        }

        public async Task<bool> Delete(int id)
        {
            var menuItemCategory = await _menuItemCategoryRepository.GetById(id);
            if (menuItemCategory is null) return false;

            return _menuItemCategoryRepository.Delete(menuItemCategory);
        }

        public async Task<MenuItemCategoryReadDto> GetById(int id)
        {
            var menuItemCategory = await _menuItemCategoryRepository.GetById(id);
            return _mapper.Map<MenuItemCategoryReadDto>(menuItemCategory);
        }

        public bool Update(MenuItemCategoryUpdateDto obj)
        {
            var menuItemCategory = _mapper.Map<MenuItemCategory>(obj);
            return _menuItemCategoryRepository.Update(menuItemCategory);
        }
    }
}
