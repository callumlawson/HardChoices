using System;
using Assets.Scripts.Framework;

namespace Assets.Scripts.EntityComponents
{
    [Serializable]
    public class Health : EntityComponent
    {
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }
    }
}
