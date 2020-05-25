using xUnitSample.Entity.Abstract;

namespace xUnitSample.Entity.Concrete
{
    public class StudentLessons : BaseEntity
    {
        public string StudentId { get; set; }
        public string LessonId { get; set; }
    }
}
