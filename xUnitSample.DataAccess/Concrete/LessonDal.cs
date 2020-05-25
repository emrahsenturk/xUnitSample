using System;
using xUnitSample.Core.Repository.Concrete;
using xUnitSample.DataAccess.Concrete.Context;
using xUnitSample.Model.Concrete;

namespace xUnitSample.DataAccess.Concrete
{
    public class LessonDal : Repository<LessonModel, Guid>
    {
        public LessonDal(xUnitSampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
