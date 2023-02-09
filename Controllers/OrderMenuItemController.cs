using FoodDelivery.Data.Repository.Interfaces;
using FoodDelivery.Models;
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
        private readonly IOrderMenuItemRepository _orderMenuItemRepository;
        public OrderMenuItemController(ILogger<OrderMenuItemController> logger, IOrderMenuItemRepository orderMenuItemRepository)
        {
            _logger = logger;
            _orderMenuItemRepository = orderMenuItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItems([FromQuery] int id) 
        {
            var result = await _orderMenuItemRepository.GetById(id);

            if (result is null) return NotFound("Order not found");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAnOrderMenuItems([FromBody] OrderMenuItem orderMenuItem) 
        {
            var result = _orderMenuItemRepository.Create(orderMenuItem);

            if (result is false) return BadRequest("Order was not made");
            return Ok(orderMenuItem);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenuItemById([FromQuery] int id)
        {
            var obj = await _orderMenuItemRepository.GetById(id);
            if (obj is null) return NotFound("Order menu item not found");

            var result = _orderMenuItemRepository.Delete(obj);
            if (result is false) return BadRequest("Order menu item was not deleted");

            return Ok("Order menu item was deleted");
        }

        [HttpPut]
        public IActionResult UpdateMenuItem([FromBody] OrderMenuItem orderMenuItem)
        {
            if (orderMenuItem is null) return BadRequest("Order menu item is not valid");

            var result = _orderMenuItemRepository.Update(orderMenuItem);
            if (result is false) return BadRequest("Order menu item was not updated");

            return Ok("Order menu item was updated");
        }

    }
}
