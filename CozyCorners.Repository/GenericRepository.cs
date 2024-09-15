using CozyCorners.Core;
using CozyCorners.Core.Models;
using CozyCorners.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Repository
{
    public class GenericRepository<T>:IGenericRepository<T> where T : BaseEntity
    {
       
        private readonly CozyDbContext _dbContext;

        public GenericRepository(CozyDbContext dbContext)
        {
           
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            //    if (typeof(T)==typeof(Product))
            //       return (IEnumerable<T>) await _storeContext.Product.Include(p=>p.productType).Include(p => p.productBrand).ToListAsync();

            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<T?> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);

        }


       
        public async Task Add(T entity)
            => await _dbContext.Set<T>().AddAsync(entity);


        public void update(T entity)
            => _dbContext.Set<T>().Update(entity);

        public void delete(T entity)
            => _dbContext.Set<T>().Remove(entity);
    }
}
