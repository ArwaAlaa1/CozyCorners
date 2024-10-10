using CozyCorners.Core.Models;
using CozyCorners.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Repositories.Contract
{
    internal interface ICategoryRepository:IGenericRepository<Category>
    {
        
    }
}
