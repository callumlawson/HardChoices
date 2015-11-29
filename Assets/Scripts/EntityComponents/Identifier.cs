using System;
using Assets.Scripts.Framework;

namespace Assets.Scripts.EntityComponents
{
    [Serializable]
    public class Identifier : EntityComponent
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
