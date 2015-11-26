using System;
using System.Collections.Generic;
using Assets.Scripts.Framework;
using Assets.Scripts.Util;

namespace Assets.Scripts.States
{
    [Serializable]
    public class GameEvent: IState
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EventOption> EventOptions { get; set; }

        public class EventOption
        {
            public string Description;
            public string Resolution;
        }
    }
}
