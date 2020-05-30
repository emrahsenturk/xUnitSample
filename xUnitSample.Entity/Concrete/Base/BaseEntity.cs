using System;
using xUnitSample.Entity.Abstract;

namespace xUnitSample.Entity.Concrete.Base
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
