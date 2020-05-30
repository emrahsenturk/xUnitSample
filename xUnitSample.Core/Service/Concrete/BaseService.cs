using System;
using System.Linq;
using System.Linq.Expressions;
using xUnitSample.Core.Entities;
using xUnitSample.Core.Repository.Abstract;
using xUnitSample.Core.Service.Abstract;

namespace xUnitSample.Core.Service.Concrete
{
    public abstract class BaseService<TDal, TModel, TId> : IService<TModel, TId>
        where TDal : IRepository<TModel, TId>
        where TModel : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        protected readonly TDal dal;

        public BaseService(TDal dal)
        {
            this.dal = dal;
        }

        public TModel GetById(TId id)
        {
            return dal.GetById(id);
        }

        public IQueryable<TModel> GetAll()
        {
            return dal.GetAll();
        }

        public IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> filter)
        {
            return dal.GetQueryable(filter);
        }

        public TModel Insert(TModel model)
        {
            return dal.Insert(model);
        }

        public TModel Update(TModel model)
        {
            return dal.Update(model);
        }

        public TModel Delete(TId id)
        {
            return dal.Delete(id);
        }

        public TModel Delete(TModel model)
        {
            return dal.Delete(model);
        }
    }
}
