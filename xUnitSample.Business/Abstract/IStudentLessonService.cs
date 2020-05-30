using System;
using xUnitSample.Core.Service.Abstract;
using xUnitSample.Model.Concrete;

namespace xUnitSample.Business.Abstract
{
    public interface IStudentLessonService : IService<StudentLessonModel, Guid>
    {
    }
}
