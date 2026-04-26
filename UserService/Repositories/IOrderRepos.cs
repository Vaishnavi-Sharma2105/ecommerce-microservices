using UserService.Models;

namespace UserService.Repositories
{
    public interface IOrderRepos
    {
        Task<Order> CreateOrder(Order order);
        Task<List<Order>> GetOrderByID(int id);
    }
}
