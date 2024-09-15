using CozyCorners.Core;
using CozyCorners.Core.Models;
using CozyCorners.Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCorners.Repository
{
    public class UnitOfWork
    {

        private readonly CozyDbContext _dbContext;
        private Hashtable _Repositories;
        public UnitOfWork(CozyDbContext dbContext)
        {

            _Repositories = new Hashtable();
            _dbContext = dbContext;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(TEntity).Name;
            if (!_Repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(_dbContext);
                _Repositories.Add(type, repository);

            }
            return _Repositories[type] as IGenericRepository<TEntity>;
        }
        public async Task<int> Complet()
         => await _dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync()
         => await _dbContext.DisposeAsync();
    } 

    

}
