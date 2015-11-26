using System;
using Assets.Scripts.Framework;
using Assets.Scripts.Util;

namespace Assets.Scripts.States
{
    [Serializable]
    public class Aircraft : IState
    {
        public string Name { get; set; }
        public int Acceleration { get; set; }
    }
}
