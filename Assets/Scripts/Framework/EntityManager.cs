using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Framework
{
    class EntityManager
    {
        public List<Entity> Entities { get; set; }

        public Guid CreateEntity(ITemplate entityTemplate)
        {
            var entity = new Entity();
            entityTemplate.EntityComponents.ForEach(component => entity.EntityComponents.Add(component));
            return entity.EntityGuid;
        }

        public bool DestroyEntity(Guid guid)
        {
            var possibleEntity = Entities.First(entity => entity.EntityGuid == guid);
            return Entities.Remove(possibleEntity);
        }
    }
}
