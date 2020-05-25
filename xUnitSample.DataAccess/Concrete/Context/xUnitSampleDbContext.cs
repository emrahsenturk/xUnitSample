using Microsoft.EntityFrameworkCore;
using xUnitSample.Model.Concrete;

namespace xUnitSample.DataAccess.Concrete.Context
{
    public class xUnitSampleDbContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<LessonModel> Lessons { get; set; }
        public DbSet<StudentLessonModel> StudentLessons { get; set; }
    }
}
