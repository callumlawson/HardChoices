using System;
using System.Collections.Generic;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class GameEvent: IObjectModel, IObservable<GameEvent>
    {
        public class EventOption
        {
            public string Description;
            public string Resolution;
        }

        public event Action<GameEvent> Updated = delegate { };

        public void ForceUpdate()
        {
            Updated(this);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<EventOption> EventOptions { get; set; }
    }
}
