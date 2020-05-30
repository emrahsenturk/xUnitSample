using System;
using xUnitSample.Business.Abstract;
using xUnitSample.Core.Service.Concrete;
using xUnitSample.DataAccess.Abstract;
using xUnitSample.Model.Concrete;

namespace xUnitSample.Business.Concrete
{
    public class LessonService : BaseService<ILessonDal, LessonModel, Guid>, ILessonService
    {
        public LessonService(ILessonDal lessonDal) : base(lessonDal)
        {
        }
    }
}
