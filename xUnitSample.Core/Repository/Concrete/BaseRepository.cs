using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using xUnitSample.Core.Entities;
using xUnitSample.Core.Repository.Abstract;

namespace xUnitSample.Core.Repository.Concrete
{
    public class BaseRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        private readonly DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public virtual IQueryable<TEntity> Entity
        {
            get { return GetEntity(); }
        }

        protected virtual DbSet<TEntity> GetEntity()
        {
            return context.Set<TEntity>();
        }

        public TEntity GetById(TId id)
        {
            return GetEntity().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return GetEntity().AsQueryable();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter)
        {
            return GetEntity().Where(filter);
        }

        public TEntity Insert(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            GetEntity().Update(entity);
            context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            if (entity == null)
                throw new Exception("Entity cannot be null");

            var entry = context.Entry(entity);
            if (entry == null)
                throw new Exception("Entry cannot be null");

            if (entry.State == EntityState.Detached)
                GetEntity().Attach(entity);
            GetEntity().Remove(entity);
            context.SaveChanges();

            return entity;
        }

        public TEntity Delete(TId id)
        {
            var entity = GetEntity().Find(id);
            if (entity is null)
            {
                throw new Exception("Entity not found!");
            }
            Delete(entity);
            return entity;
        }
    }
}
