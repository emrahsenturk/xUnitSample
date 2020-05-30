using System;
using xUnitSample.Core.Repository.Concrete;
using xUnitSample.DataAccess.Abstract;
using xUnitSample.DataAccess.Concrete.Context;
using xUnitSample.Model.Concrete;

namespace xUnitSample.DataAccess.Concrete
{
    public class StudentLessonDal : BaseRepository<StudentLessonModel, Guid>, IStudentLessonDal
    {
        public StudentLessonDal(xUnitSampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
