using System;
using Assets.Scripts.Framework;

namespace Assets.Scripts.EntityComponents
{
    [Serializable]
    public class Aircraft : EntityComponent
    {
        public float Weight { get; set; }
        public float AirSpeed { get; set; }
    }
}
