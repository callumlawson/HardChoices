using System;
using Assets.Scripts.Framework;
using Assets.Scripts.Util;

namespace Assets.Scripts.States
{
    [Serializable]
    public class Agent : IState
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public int Motivation { get; set; }
    }
}
