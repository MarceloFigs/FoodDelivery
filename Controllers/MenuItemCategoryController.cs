

using FoodDelivery.Data.Repository.Interfaces;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemCategoryController : ControllerBase
    {
        private ILogger<MenuItemCategoryController> _logger;
        private IMenuItemCategoryRepository _menuItemCategoryRepository;
        public MenuItemCategoryController(ILogger<MenuItemCategoryController> logger,
            IMenuItemCategoryRepository menuItemCategoryRepository)
        {
            _logger = logger;
            _menuItemCategoryRepository = menuItemCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItensCategoriesById([FromQuery] int id)
        {
            _logger.LogInformation("Searching categories");
            var result = await _menuItemCategoryRepository.GetById(id);

            if (result is null) return NotFound("Itens not found");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMenuItemCategory([FromBody] MenuItemCategory menuItemCategory)
        {
            _logger.LogInformation("Creating category");
            var result = _menuItemCategoryRepository.Create(menuItemCategory);

            if (result is false) return BadRequest("Error: menu item category was not created");
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenuItemCategoryById([FromQuery] int id)
        {
            var obj = await _menuItemCategoryRepository.GetById(id);
            if (obj is null) return NotFound("Menu item category not found");

            var result = _menuItemCategoryRepository.Delete(obj);
            if (result is false) return BadRequest("Menu item category was not deleted");

            return Ok("Menu item category was deleted");
        }

        [HttpPut]
        public IActionResult UpdateMenuItemCategory([FromBody] MenuItemCategory menuItemCategory)
        {
            if (menuItemCategory is null) return BadRequest("Menu item category is not valid");

            var result = _menuItemCategoryRepository.Update(menuItemCategory);
            if (result is false) return BadRequest("Menu item category was not updated");

            return Ok("Menu item category was updated");
        }
    }
}
