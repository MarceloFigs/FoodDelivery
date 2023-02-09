using FoodDelivery.Data.Repository.Interfaces;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodOrderController : ControllerBase
    {
        private readonly IFoodOrderRepository _foodOrderRepository;
        public FoodOrderController(IFoodOrderRepository foodOrderRepository)
        {
            _foodOrderRepository = foodOrderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderById([FromQuery] int id)
        {
            var result = await _foodOrderRepository.GetById(id);

            if (result is null) return NotFound("Order was not found");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAnOrder([FromBody] FoodOrder foodOrder)
        {
            var result = _foodOrderRepository.Create(foodOrder);

            if (result is false) return BadRequest("Your order was not created");
            return Ok(foodOrder);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFoodOrderById([FromQuery] int id)
        {
            var obj = await _foodOrderRepository.GetById(id);
            if (obj is null) return NotFound("Food order not found");

            var result = _foodOrderRepository.Delete(obj);
            if (result is false) return BadRequest("Food order was not deleted");

            return Ok("Food order was deleted");
        }

        [HttpPut]
        public IActionResult UpdateFoodOrder([FromBody] FoodOrder foodOrder)
        {
            if (foodOrder is null) return BadRequest("Food order is not valid");

            var result = _foodOrderRepository.Update(foodOrder);
            if (result is false) return BadRequest("Food order was not updated");

            return Ok("Food order was updated");
        }
    }
}
