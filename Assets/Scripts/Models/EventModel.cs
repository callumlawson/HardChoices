using System;
using Assets.Scripts.Labels;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class EventModel: ObjectModel, IObservable<EventModel>
    {
        public EventType Type { get; set; }

        public event Action<EventModel> Updated = delegate { };

        public EventModel(){}

        public EventModel(EventType type)
        {
            Type = type;
        }
    }
}
