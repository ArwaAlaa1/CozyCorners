using CozyCorners.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models
{
    public class Review:BaseEntity
    {
        
        public string AppUserId { get; set; }
        public int ProductID { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
    }
}
