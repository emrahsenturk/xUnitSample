using System;
using xUnitSample.Entity.Abstract;

namespace xUnitSample.Entity.Concrete
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
