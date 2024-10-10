﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
    
     //public int? ParentCategoryId { get; set; }
        //public Category ParentCategory { get; set; }
        //public ICollection<Category> SubCategories { get; set; }


    }
}
