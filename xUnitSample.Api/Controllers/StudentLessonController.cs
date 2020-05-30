using Microsoft.AspNetCore.Mvc;
using xUnitSample.Api.Controllers.Base;
using xUnitSample.Business.Abstract;
using xUnitSample.Model.Concrete;

namespace xUnitSample.Api.Controllers
{
    [Route("api/[controller]")]
    public class StudentLessonController : BaseApiController<StudentLessonModel>
    {
        private readonly IStudentLessonService studentLessonService;

        public StudentLessonController(IStudentLessonService studentLessonService) : base(studentLessonService)
        {
            this.studentLessonService = studentLessonService;
        }
    }
}
