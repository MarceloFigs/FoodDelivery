using FoodDelivery.Data.Repository.Interfaces;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
    }
}
