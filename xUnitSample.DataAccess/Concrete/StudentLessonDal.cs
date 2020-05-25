using System;
using xUnitSample.Core.Repository.Concrete;
using xUnitSample.DataAccess.Concrete.Context;
using xUnitSample.Model.Concrete;

namespace xUnitSample.DataAccess.Concrete
{
    public class StudentLessonDal : Repository<StudentLessonModel, Guid>
    {
        public StudentLessonDal(xUnitSampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
