using FoodDelivery.Dtos.FoodOrder;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodOrderController : ControllerBase
    {
        private readonly IFoodOrderService _foodOrderService;
        public FoodOrderController(IFoodOrderService foodOrderService)
        {
            _foodOrderService = foodOrderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderById([FromQuery] int id)
        {
            var result = await _foodOrderService.GetById(id);

            if (result is null) return NotFound("Order was not found");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAnOrder([FromBody] FoodOrderCreateDto foodOrder)
        {
            var result = _foodOrderService.Create(foodOrder);

            if (result is false) return BadRequest("Your order was not created");
            return Ok(foodOrder);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFoodOrderById([FromQuery] int id)
        {
            var result = await _foodOrderService.Delete(id);
            if (result is false) return BadRequest("Food order was not deleted");

            return Ok("Food order was deleted");
        }

        [HttpPut]
        public IActionResult UpdateFoodOrder([FromBody] FoodOrderUpdateDto foodOrder)
        {
            if (foodOrder is null) return BadRequest("Food order is not valid");

            var result = _foodOrderService.Update(foodOrder);
            if (result is false) return BadRequest("Food order was not updated");

            return Ok("Food order was updated");
        }
    }
}
