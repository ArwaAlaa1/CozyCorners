using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models.Order
{
    public class CheckOut
    {
        public string Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
       
        public OrderSummary OrderDetails { get; set; }
        public Address Address { get; set; }
    }
}
