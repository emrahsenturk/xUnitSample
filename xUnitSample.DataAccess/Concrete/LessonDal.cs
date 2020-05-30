using System;
using xUnitSample.Core.Repository.Concrete;
using xUnitSample.DataAccess.Abstract;
using xUnitSample.DataAccess.Concrete.Context;
using xUnitSample.Model.Concrete;

namespace xUnitSample.DataAccess.Concrete
{
    public class LessonDal : BaseRepository<LessonModel, Guid>, ILessonDal
    {
        public LessonDal(xUnitSampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
