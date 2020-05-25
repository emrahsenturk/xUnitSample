using System;

namespace xUnitSample.Entity.Abstract
{
    public class BaseEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
