using System.Collections.Generic;
using Assets.Scripts.EntityComponents;
using Assets.Scripts.Framework;

namespace Assets.Scripts.EntityTemplates
{
    public class PilotTemplate : ITemplate
    {
        public List<EntityComponent> EntityComponents { get; set; }

        public PilotTemplate()
        {
            EntityComponents = new List<EntityComponent>
            {
                new Identifier(),
                new Pilot(),
                new Health()
            };
        }
    }

    public class AircraftTemplate : ITemplate
    {
        public List<EntityComponent> EntityComponents { get; set; }

        public AircraftTemplate()
        {
            EntityComponents = new List<EntityComponent>
            {
                new Identifier(),
                new Aircraft(),
                new Health()
            };
        }
    }
}