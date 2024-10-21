using CozyCorners.Core.Models.Order;
using CozyCorners.Core.Repositories.Contract;
using CozyCorners.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Repository.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(CozyDbContext cozyDbContext):base(cozyDbContext)
        {
                
        }
        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            var orders= await _dbContext.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderById(int id)
        {
            var orders = await _dbContext.Orders.Include(item => item.Items).FirstAsync(i=>i.Id==id);
            return orders;
        }
        public async Task<IEnumerable<Order>> GetOrdersForUser(string email)
        {
            var orders = await _dbContext.Orders.Include(item => item.Items).Where(i => i.CustomerEmail== email).ToListAsync();
            return orders;
        }
        public async Task<Order> GetOrderForUser(string email)
        {
            var orders = await _dbContext.Orders.Include(item => item.Items).FirstAsync(i => i.CustomerEmail == email);
            return orders;
        }
    }
}
