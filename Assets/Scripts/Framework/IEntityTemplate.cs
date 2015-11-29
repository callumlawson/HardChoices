using System;
using System.Collections.Generic;

namespace Assets.Scripts.Framework
{
    public interface IEntityTemplate
    {
        List<Type> EntityComponents { get; set; }
    }
}
