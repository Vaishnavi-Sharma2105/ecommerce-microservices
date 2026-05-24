using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using UserService.DTOs;
using UserService.Models;
using UserService.Services;
using Microsoft.AspNetCore.Authorization;

namespace UserService.Controllers
{
    
    [ApiController]
    [Route("api/orders")]
    [Authorize]
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, UpdateOrderDTO request)
        {
            var success = await _service.UpdateOrder(request, id);

            if (!success)
                return BadRequest("Invalid data or order not found");

            return Ok(new ApiResponse<string>
            {
                success = true,
                message = "Updation done",
                Data = null
            });
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteById(int id)
        {
           var res= await _service.DeleteOrder(id);
            if (res == true)
                return Ok(new ApiResponse<string>
                {
                    success = true,
                    message = "Deletion done",
                    Data = null
                });
            else return BadRequest("Id not found");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _service.GetAllOrders();
            if (result == null) return BadRequest("No orders FOund");
            return Ok(new ApiResponse<List<Order>>
            {
                success = true,
                message = "Order Fetched successfully",
                Data = result
            }); // for response consistency we have added apiresponse and sending result using that.
        }
    }
}
