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
        public async Task<Order?> GetById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }
        public async Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }
    }
}
