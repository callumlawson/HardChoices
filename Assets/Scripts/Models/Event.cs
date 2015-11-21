using System;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Event: ObjectModel<Event>
    {
        private int predicate;
        public int Predicate
        {
            get { return predicate; }
            set { predicate = value; Update(); }
        }

        private int resolution;
        public int Resolution
        {
            get { return resolution; }
            set { resolution = value; Update(); }
        }
    }
}
