using System;
using Assets.Scripts.Framework;

namespace Assets.Scripts.EntityComponents
{
    [Serializable]
    public class Pilot : EntityComponent
    {
        public float Ability { get; set; }
    }
}
