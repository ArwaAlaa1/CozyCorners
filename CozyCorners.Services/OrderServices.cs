using CozyCorners.Core;
using CozyCorners.Core.Models;
using CozyCorners.Core.Models.Order;
using CozyCorners.Core.Repositories.Contract;
using CozyCorners.Core.Services.Contract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderServices(ICartRepository cartRepository,IUnitOfWork unitOfWork)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Order?> CreateOrderAsync(string customerEmail, string basketId, int DeliveryId,Address address)
        {
            var cart = await _cartRepository.GetCustomerCartAsync(basketId);

            var orderItems = new List<OrderItem>();
            if (cart?.CartItems?.Count() > 0)
            {

                foreach (var item in cart.CartItems)
                {
                    var product = await _unitOfWork.Repository<Product>().GetById(item.Id);
                    var ProductOrderItem = new ProductItemOrder(product.Id, product.Name, product.PhotoPath);
                    var orderitem = new OrderItem(ProductOrderItem, item.Quantity, item.Price);
                    orderItems.Add(orderitem);
                }

            }

            var subtotal = orderItems.Sum(item => item.PriceAtPurchase * item.Quantity);
            var deliverymethod=await _unitOfWork.Repository<DeliveryMethod>().GetById(DeliveryId);
            var order=new Order(customerEmail,address,  deliverymethod,orderItems,subtotal);
            await _unitOfWork.Repository<Order>().Add(order);
            var row=await _unitOfWork.Complet();
            if (row <= 0) return null;
        
            return order;

        }

        public Task<Order> GetOrderByIdForUserAsync(int orderid, string CustomerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string CustomerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
