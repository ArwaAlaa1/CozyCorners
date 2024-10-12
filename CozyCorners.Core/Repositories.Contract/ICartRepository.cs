using CozyCorners.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Repositories.Contract
{
    public interface ICartRepository
    {
       Task<CustomerCart?> GetCustomerCartAsync(string BasketId);
        int GetCustomerCartItemsAsync(string BasketId);

        Task<CustomerCart?> UpdateBasketAsync(CustomerCart cart);    
        Task<bool> DeleteCartAsync(string BasketId);
    }
}
