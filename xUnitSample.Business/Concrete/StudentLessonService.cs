using System;
using xUnitSample.Business.Abstract;
using xUnitSample.Core.Service.Concrete;
using xUnitSample.DataAccess.Abstract;
using xUnitSample.Model.Concrete;

namespace xUnitSample.Business.Concrete
{
    public class StudentLessonService : BaseService<IStudentLessonDal, StudentLessonModel, Guid>, IStudentLessonService
    {
        public StudentLessonService(IStudentLessonDal studentDal) : base(studentDal)
        {
        }
    }
}
