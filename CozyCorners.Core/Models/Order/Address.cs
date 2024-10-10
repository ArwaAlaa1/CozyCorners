using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models.Order
{
	public class Address
	{
        public Address()
        {
            
        }
        public Address(string fName, string lName, string city, string country, string street)
		{
			FName = fName;
			LName = lName;
			City = city;
			Country = country;
			Street = street;
		}

		public string FName { get; set; }
		public string LName { get; set; }

		public string City { get; set; }
		public string Country { get; set; }
		public string Street { get; set; }
	
	}
}
