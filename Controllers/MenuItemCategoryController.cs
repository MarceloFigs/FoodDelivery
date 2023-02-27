using FoodDelivery.Dtos.MenuItemCategoryDto;
using FoodDelivery.Services.Interfaces;
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
        private IMenuItemCategoryService _menuItemCategoryService;
        public MenuItemCategoryController(ILogger<MenuItemCategoryController> logger,
            IMenuItemCategoryService menuItemCategoryService)
        {
            _logger = logger;
            _menuItemCategoryService = menuItemCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItensCategoriesById([FromQuery] int id)
        {
            _logger.LogInformation("Searching categories");
            var result = await _menuItemCategoryService.GetById(id);

            if (result is null) return NotFound("Itens not found");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMenuItemCategory([FromBody] MenuItemCategoryCreateDto menuItemCategory)
        {
            _logger.LogInformation("Creating category");
            var result = _menuItemCategoryService.Create(menuItemCategory);

            if (result is false) return BadRequest("Error: menu item category was not created");
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenuItemCategoryById([FromQuery] int id)
        {
            _logger.LogInformation("Deleting category");
            var result = await _menuItemCategoryService.Delete(id);
            if (result is false) return BadRequest("Menu item category was not deleted");

            return Ok("Menu item category was deleted");
        }

        [HttpPut]
        public IActionResult UpdateMenuItemCategory([FromBody] MenuItemCategoryUpdateDto menuItemCategory)
        {
            _logger.LogInformation("Editing category");
            if (menuItemCategory is null) return BadRequest("Menu item category is not valid");

            var result = _menuItemCategoryService.Update(menuItemCategory);
            if (result is false) return BadRequest("Menu item category was not updated");

            return Ok("Menu item category was updated");
        }
    }
}
