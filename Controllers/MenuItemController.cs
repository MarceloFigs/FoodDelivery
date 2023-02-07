using FoodDelivery.Data.Repository.Interfaces;
using FoodDelivery.Models;
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
        private readonly IMenuItemRepository _menuItemRepository;
        public MenuItemController(ILogger<MenuItemController> logger, IMenuItemRepository menuItemRepository)
        {
            _logger = logger;
            _menuItemRepository = menuItemRepository;
        }

        [HttpGet("{menuItemID}", Name = "GetAllMenuItemsById")]
        public async Task<IActionResult> GetMenuItemById([FromQuery] int menuItemId)
        {
            _logger.LogInformation("Searching menu itens");
            var result = await _menuItemRepository.GetById(menuItemId);

            if (result is null) return NotFound("Item not found");
            return Ok(result);
        }

        [HttpGet("{menuItemByCategory}/menuitemsbycategory", Name = "GetAllMenuItemsByCategory")]
        public async Task<IActionResult> GetMenuItemByCategory([FromQuery] int menuItemCategoryId) 
        {
            _logger.LogInformation("Searching menu items by categories");
            var result = await _menuItemRepository.GetAllMenuItemsByCategoryId(menuItemCategoryId);

            if (result is null) return NotFound("Item not found");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMenuItem([FromBody] MenuItem menuItem) 
        {
            _logger.LogInformation("Creating menu items");
            if (menuItem is null) return BadRequest("Menu item was not valid");

            var result = _menuItemRepository.Create(menuItem);

            if (result is false) return BadRequest("Menu item was not created");
            return Ok(menuItem);
        }
    }
}
