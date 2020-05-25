using System;
using xUnitSample.Core.Repository.Abstract;
using xUnitSample.Model.Concrete;

namespace xUnitSample.DataAccess.Abstract
{
    public interface IStudentDal : IRepository<StudentModel, Guid>
    {
    }
}
