using CozyCorners.Core.Models;
using CozyCorners.Core.Repositories.Contract;
using CozyCorners.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(CozyDbContext cozyDbContext):base(cozyDbContext)
        {
            
        }
        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products.Include(p=>p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
          
            return await _dbContext.Set<Product>().Include(p=>p.Category).AsNoTracking().ToListAsync();
        }

		public async Task<IReadOnlyList<Product>> GetTopProducts(int i)
        {
            return await _dbContext.Products.Take(i).ToListAsync();

        }
    }
}
