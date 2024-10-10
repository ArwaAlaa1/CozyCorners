using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models.Order
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
            
        }
        public OrderItem(ProductItemOrder product, int quantity, decimal priceAtPurchase)
		{
			Product = product;
			Quantity = quantity;
			PriceAtPurchase = priceAtPurchase;
			
		}

		public ProductItemOrder Product { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }
  


    }
}
