using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CozyCorners.Core.Models.Identity;

namespace CozyCorners.Core.Models
{
    public class Favorite
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
