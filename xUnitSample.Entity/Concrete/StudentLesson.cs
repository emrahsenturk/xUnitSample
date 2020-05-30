using xUnitSample.Entity.Concrete.Base;

namespace xUnitSample.Entity.Concrete
{
    public class StudentLesson : BaseEntity
    {
        public string StudentId { get; set; }
        public string LessonId { get; set; }
    }
}
