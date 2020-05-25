using System;
using xUnitSample.Core.Repository.Concrete;
using xUnitSample.DataAccess.Concrete.Context;
using xUnitSample.Model.Concrete;

namespace xUnitSample.DataAccess.Concrete
{
    public class StudentDal : Repository<StudentModel, Guid>
    {
        public StudentDal(xUnitSampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
