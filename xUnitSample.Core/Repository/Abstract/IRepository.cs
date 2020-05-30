using System;
using System.Linq;
using System.Linq.Expressions;
using xUnitSample.Core.Entities;

namespace xUnitSample.Core.Repository.Abstract
{
    public interface IRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        IQueryable<TEntity> Entity { get; }

        TEntity GetById(TId id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        TEntity Delete(TId id);
    }
}
