using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public interface IGenericRepository<TEntity> where TEntity : class
{
    TEntity GetById(object id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);

}
