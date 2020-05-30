using System;

namespace xUnitSample.Entity.Abstract
{
    public interface IEntity<TId>
        where TId : IEquatable<TId>
    {
        TId Id { get; set; }
    }
}
