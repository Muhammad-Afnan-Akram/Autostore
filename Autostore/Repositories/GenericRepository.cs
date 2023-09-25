using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Autostore.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AutoStoreContext _dbContext;
        private readonly DbSet<TEntity> _entitySet;

        public GenericRepository(AutoStoreContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _entitySet.Add(entity);
        }
      
        public void Delete(TEntity entity)
        {
            _entitySet.Find(entity);
            _entitySet.Remove(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entitySet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entitySet.ToList();
        }

        public TEntity GetById(object id)
        {
            return _entitySet.Find(id);
        }

        public void Update(TEntity entity)
        {
            _entitySet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        
    }
}
