using System;
using xUnitSample.Core.Service.Abstract;
using xUnitSample.Model.Concrete;

namespace xUnitSample.Business.Abstract
{
    public interface ILessonService : IService<LessonModel, Guid>
    {
    }
}
