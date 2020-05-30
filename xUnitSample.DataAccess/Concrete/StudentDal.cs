using System;
using xUnitSample.Core.Repository.Concrete;
using xUnitSample.DataAccess.Abstract;
using xUnitSample.DataAccess.Concrete.Context;
using xUnitSample.Model.Concrete;

namespace xUnitSample.DataAccess.Concrete
{
    public class StudentDal : BaseRepository<StudentModel, Guid>, IStudentDal
    {
        public StudentDal(xUnitSampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
