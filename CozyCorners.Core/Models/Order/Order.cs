using CozyCorners.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models.Order
{
    public class Order : BaseEntity
    {
        public Order()
        {
            
        }
        public Order(string customerEmail,  Address addressShipping, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal)
		{
			CustomerEmail = customerEmail;
			AddressShipping = addressShipping;
			DeliveryMethod = deliveryMethod;
			Items = items;
			SubTotal = subTotal;
			
		}

		public string CustomerEmail { get; set; }
       
        public DateTimeOffset OrderDate { get; set; }=DateTimeOffset.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public Address AddressShipping { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public int? DeliveryMethodId { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
        public decimal SubTotal { get; set; }
         
        public decimal Total()
        {
            return SubTotal+ DeliveryMethod.Cost;
        }
        public string PaymentMethodId { get; set; }=string.Empty;
      

      
    }
}
