using System;
using Assets.Scripts.Framework;
using Assets.Scripts.Util;

namespace Assets.Scripts.States
{
    [Serializable]
    public class AirBase : IState
    {
        public string Name { get; set; }
        public int RunwayLengthInMeters { get; set; }
    }
}
