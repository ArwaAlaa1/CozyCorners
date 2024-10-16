using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models.Order
{
    public class OrderSummary
    {
        public int NumberOfItems{ get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal SubTotal { get; set; }
    }
}
