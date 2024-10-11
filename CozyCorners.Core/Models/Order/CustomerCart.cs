using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models.Order
{
	public class CustomerCart
	{
        public string Id { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
