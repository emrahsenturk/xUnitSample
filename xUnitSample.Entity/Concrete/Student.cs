using xUnitSample.Entity.Concrete.Base;

namespace xUnitSample.Entity.Concrete
{
    public class Student : BaseEntity
    {
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
