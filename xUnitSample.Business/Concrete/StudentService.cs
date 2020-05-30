using System;
using xUnitSample.Business.Abstract;
using xUnitSample.Core.Service.Concrete;
using xUnitSample.DataAccess.Abstract;
using xUnitSample.Model.Concrete;

namespace xUnitSample.Business.Concrete
{
    public class StudentService : BaseService<IStudentDal, StudentModel, Guid>, IStudentService
    {
        public StudentService(IStudentDal studentDal) : base(studentDal)
        {
        }
    }
}
