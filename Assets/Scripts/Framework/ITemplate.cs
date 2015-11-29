using System.Collections.Generic;

namespace Assets.Scripts.Framework
{
    public interface ITemplate
    {
        List<EntityComponent> EntityComponents { get; set; }
    }
}
