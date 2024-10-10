using CozyCorners.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core.Repositories.Contract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<IReadOnlyList<Product>> GetTopProducts(int i);

	}
}
