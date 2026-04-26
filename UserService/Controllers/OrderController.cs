using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController:ControllerBase

    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto request)
        {
            var result = await _service.PlaceOrder(request);
            return Ok(result);
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrders(int userId)
        {
            var result = await _service.GetOrderByID(userId);
            if (result == null || result.Count == 0)
                return NotFound("No orders found for this user");
            return Ok(result);
        }

    }
}
