using FoodDelivery.Data.Repository.Interfaces;
using FoodDelivery.Dtos.OrderMenuItemDto;
using FoodDelivery.Models;
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
            var result = await _orderMenuItemService.GetById(id);

            if (result is null) return NotFound("Order not found");
            return Ok(result);
        }
        
        [HttpGet("{foodOrderId}", Name = "GetOrderMenuItemsByFoodOrderId")]
        public async Task<IActionResult> GetOrderMenuItemsByFoodOrderId(int foodOrderId)
        {
            var result = await _orderMenuItemService.GetOrderMenuItemsByFoodOrderId(foodOrderId);
            decimal price = 0;
            foreach (var item in result)
            {
                price += (item.MenuItem.Price * item.QuantityOrdered);
            }

            if (result is null) return NotFound("Order not found");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAnOrderMenuItems([FromBody] OrderMenuItemCreateDto orderMenuItem) 
        {
            var result = _orderMenuItemService.Create(orderMenuItem);

            if (result is false) return BadRequest("Order was not made");
            return Ok(orderMenuItem);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenuItemById([FromQuery] int id)
        {
            //var obj = await _orderMenuItemService.GetById(id);
            //if (obj is null) return NotFound("Order menu item not found");

            var result = await _orderMenuItemService.Delete(id);
            if (result is false) return BadRequest("Order menu item was not deleted");

            return Ok("Order menu item was deleted");
        }

        [HttpPut]
        public IActionResult UpdateMenuItem([FromBody] OrderMenuItemUpdateDto orderMenuItem)
        {
            if (orderMenuItem is null) return BadRequest("Order menu item is not valid");

            var result = _orderMenuItemService.Update(orderMenuItem);
            if (result is false) return BadRequest("Order menu item was not updated");

            return Ok("Order menu item was updated");
        }

    }
}
