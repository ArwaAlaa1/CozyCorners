using CozyCorners.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Services.Contract
{
    public interface IOrderServices
    {
        Task<Order?> CreateOrderAsync(string customerEmail, string basketId, int DeliveryId,Address  address);

        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string CustomerEmail);

        Task<Order> GetOrderByIdForUserAsync(int orderid,string CustomerEmail);


    }
}
