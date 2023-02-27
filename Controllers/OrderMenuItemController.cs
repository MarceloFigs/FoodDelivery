using FoodDelivery.Dtos.OrderMenuItemDto;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderMenuItemController : ControllerBase
    {
        private readonly ILogger<OrderMenuItemController> _logger;
        private readonly IOrderMenuItemService _orderMenuItemService;
        public OrderMenuItemController(ILogger<OrderMenuItemController> logger, IOrderMenuItemService orderMenuItemService)
        {
            _logger = logger;
            _orderMenuItemService = orderMenuItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItems([FromQuery] int id) 
        {
            _logger.LogInformation("Searching order items");
            var result = await _orderMenuItemService.GetById(id);

            if (result is null) return NotFound("Order not found");
            return Ok(result);
        }
        
        [HttpGet("{foodOrderId}", Name = "GetOrderMenuItemsByFoodOrderId")]
        public async Task<IActionResult> GetOrderMenuItemsByFoodOrderId(int foodOrderId)
        {
            _logger.LogInformation("Searching menu items by food order");
            var result = await _orderMenuItemService.GetOrderMenuItemsByFoodOrderId(foodOrderId);

            if (result is null) return NotFound("Order not found");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAnOrderMenuItems([FromBody] OrderMenuItemCreateDto orderMenuItem) 
        {
            _logger.LogInformation("Adding menu items to an order");
            var result = _orderMenuItemService.Create(orderMenuItem);

            if (result is false) return BadRequest("Order was not made");
            return Ok(orderMenuItem);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenuItemById([FromQuery] int id)
        {
            _logger.LogInformation("Deleting menu items from order");
            var result = await _orderMenuItemService.Delete(id);
            if (result is false) return BadRequest("Order menu item was not deleted");

            return Ok("Order menu item was deleted");
        }

        [HttpPut]
        public IActionResult UpdateMenuItem([FromBody] OrderMenuItemUpdateDto orderMenuItem)
        {
            _logger.LogInformation("Editing menu items from an order");
            if (orderMenuItem is null) return BadRequest("Order menu item is not valid");

            var result = _orderMenuItemService.Update(orderMenuItem);
            if (result is false) return BadRequest("Order menu item was not updated");

            return Ok("Order menu item was updated");
        }

    }
}
