using CozyCorners.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Core
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        public Task<IReadOnlyList<T>> GetAllAsync();

        public Task<T?> GetById(int id);
   
        Task Add(T entity);
        void update(T entity);
        void delete(T entity);

    }
}
