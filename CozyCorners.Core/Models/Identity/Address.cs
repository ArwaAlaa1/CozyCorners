using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models.Identity
{
    public class Address:BaseEntity
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string Region { get; set; }
        public string Details { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
