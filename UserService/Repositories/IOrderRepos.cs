using UserService.Models;

namespace UserService.Repositories
{
    public interface IOrderRepos
    {
        Task<Order> CreateOrder(Order order);
        Task<List<Order>> GetOrderByID(int id);
        Task<Order?> GetById(int id);
        Task UpdateOrder(Order order);

        Task<bool> DeleteOrder(int id);
        Task<List<Order>> GetAllOrders();

        

    }
}
