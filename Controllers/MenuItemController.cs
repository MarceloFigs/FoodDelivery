using FoodDelivery.Dtos.MenuItem;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly ILogger<MenuItemController> _logger;
        private readonly IMenuItemService _menuItemService;
        public MenuItemController(ILogger<MenuItemController> logger, IMenuItemService menuItemService)
        {
            _logger = logger;
            _menuItemService = menuItemService;
        }

        [HttpGet("{menuItemId}", Name = "GetAllMenuItemsById")]
        public async Task<IActionResult> GetMenuItemById(int menuItemId)
        {
            _logger.LogInformation("Searching menu items");
            var result = await _menuItemService.GetById(menuItemId);

            if (result is null) return NotFound("Item not found");
            return Ok(result);
        }

        [HttpGet("{menuItemCategoryId}/menuitemsbycategory", Name = "GetAllMenuItemsByCategory")]
        public async Task<IActionResult> GetMenuItemByCategory(int menuItemCategoryId) 
        {
            _logger.LogInformation("Searching menu items by categories");
            var result = await _menuItemService.GetAllMenuItemsByCategoryId(menuItemCategoryId);

            if (result is null) return NotFound("Item not found");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMenuItem([FromBody] MenuItemCreateDto menuItem) 
        {
            _logger.LogInformation("Creating menu items");
            if (menuItem is null) return BadRequest("Menu item was not valid");

            var result = _menuItemService.Create(menuItem);

            if (result is false) return BadRequest("Menu item was not created");
            return Ok(menuItem);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenuItemById([FromQuery] int id) 
        {
            _logger.LogInformation("Deleting menu items");
            var result = await _menuItemService.Delete(id);
            if (result is false) return BadRequest("Menu item was not deleted");

            return Ok("Item was deleted");
        }

        [HttpPut]
        public IActionResult UpdateMenuItem([FromBody] MenuItemUpdateDto menuItem)
        {
            _logger.LogInformation("Editing menu items");
            if (menuItem is null) return BadRequest("Menu item is not valid");

            var result = _menuItemService.Update(menuItem);
            if (result is false) return BadRequest("Menu item was not updated");

            return Ok("Item was updated");
        }
    }
}
