using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;

namespace UserService.Repositories
{
    public class OrderRepos:IOrderRepos
    {
        private readonly AppDbContext _context;
        public OrderRepos(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<List<Order>> GetOrderByID(int id)
        {
            return await _context.Orders.Where(o => o.UserId == id).ToListAsync(); 
        }
    }
}
