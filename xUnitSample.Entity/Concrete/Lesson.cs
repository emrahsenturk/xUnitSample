using System;
using System.Collections.Generic;
using System.Text;
using xUnitSample.Entity.Abstract;

namespace xUnitSample.Entity.Concrete
{
    public class Lesson : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
