using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Framework
{
    public class Entity
    {
        public Guid EntityGuid;
        public List<EntityComponent> EntityComponents;

        public Entity()
        {
            EntityGuid = new Guid();
        }

        public EntityComponent GetComponent<T>()
        {
            return EntityComponents.First(component => component.GetType() == typeof (T));
        }
    }
}
