using UserService.Services;
using UserService.Models;
using UserService.Repositories;
using UserService.DTOs;
namespace UserService.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepos _repo;
        public OrderService(IOrderRepos repo)
        {
            _repo = repo;   
        }
        public async Task<OrderDTO> PlaceOrder(CreateOrderDto request)
        {
            if (request.amount <= 0)
                throw new Exception("Invalid amount");

            var order = new Order
            {
                UserId = request.userId,
                TotalAmount = request.amount,
                CreatedAt = DateTime.UtcNow
            };
            var created =await _repo.CreateOrder(order);
            return new OrderDTO
            {
                Id = created.Id,
                TotalAmount = created.TotalAmount
            };

        }
        public async Task<List<OrderDTO>> GetOrderByID(int id)
            {
            var orders = await _repo.GetOrderByID(id);
            return orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                TotalAmount = o.TotalAmount
            }).ToList();
        }
        public async Task<bool> UpdateOrder(UpdateOrderDTO request, int id)
        {
            var order = await _repo.GetById(id);
            if (order == null)
                return false;
            if(request.TotalAmount<=0)
                return false;
            order.TotalAmount = request.TotalAmount;

            await _repo.UpdateOrder(order);

            return true;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            
          return await _repo.DeleteOrder(id);

        }
        public async Task<List<Order>> GetAllOrders()
        {
            return await _repo.GetAllOrders();
        }
    }
}
