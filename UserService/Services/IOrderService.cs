using UserService.Models;
using UserService.DTOs;

namespace UserService.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> PlaceOrder(CreateOrderDto request);
        Task<List<OrderDTO>> GetOrderByID(int id);
        Task<bool> UpdateOrder(UpdateOrderDTO request, int id);
        Task<bool> DeleteOrder(int id);

        Task<List<Order>> GetAllOrders();
    }
}
