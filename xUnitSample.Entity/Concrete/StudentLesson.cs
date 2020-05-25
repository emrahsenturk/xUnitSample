using xUnitSample.Entity.Abstract;

namespace xUnitSample.Entity.Concrete
{
    public class StudentLesson : BaseEntity
    {
        public string StudentId { get; set; }
        public string LessonId { get; set; }
    }
}
