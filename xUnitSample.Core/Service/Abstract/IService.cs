using System;
using System.Linq;
using System.Linq.Expressions;
using xUnitSample.Entity.Abstract;

namespace xUnitSample.Core.Service.Abstract
{
    public interface IService<TModel, TId>
        where TModel : class, IEntity<TId>
        where TId : IEquatable<TId>
    {
        TModel GetById(TId id);
        IQueryable<TModel> GetAll();
        IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> filter);
        TModel Insert(TModel model);
        TModel Update(TModel model);
        TModel Delete(TId id);
        TModel Delete(TModel model);
    }
}
