using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models.Order
{
	public class DeliveryMethod:BaseEntity
	{
        public DeliveryMethod()
        {
            
        }
        public DeliveryMethod(string name, string description, string deliveryTime, decimal cost)
		{
			Name = name;
			Description = description;
			DeliveryTime = deliveryTime;
			Cost = cost;
		}

		public string Name { get; set; }
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public decimal Cost { get; set; }
    }
}
