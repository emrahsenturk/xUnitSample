using Microsoft.AspNetCore.Mvc;
using xUnitSample.Api.Controllers.Base;
using xUnitSample.Business.Abstract;
using xUnitSample.Model.Concrete;

namespace xUnitSample.Api.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : BaseApiController<StudentModel>
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService) : base(studentService)
        {
            this.studentService = studentService;
        }
    }
}
