using Microsoft.AspNetCore.Mvc;
using xUnitSample.Api.Controllers.Base;
using xUnitSample.Business.Abstract;
using xUnitSample.Model.Concrete;

namespace xUnitSample.Api.Controllers
{
    [Route("api/[controller]")]
    public class LessonController : BaseApiController<LessonModel>
    {
        private readonly ILessonService lessonService;

        public LessonController(ILessonService lessonService) : base(lessonService)
        {
            this.lessonService = lessonService;
        }
    }
}
