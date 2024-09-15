using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCreated { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
