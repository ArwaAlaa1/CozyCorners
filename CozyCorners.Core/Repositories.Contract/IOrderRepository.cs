using CozyCorners.Core.Models.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Repositories.Contract
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<Order> GetOrderById(int id);
        Task<IEnumerable<Order>> GetAllOrder();
        Task<IEnumerable<Order>> GetOrdersForUser(string email);

       Task<Order> GetOrderForUser(string email);
        
    }
}
