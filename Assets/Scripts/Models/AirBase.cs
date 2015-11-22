using System;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class AirBase : IObjectModel, IObservable<AirBase>
    {
        public event Action<AirBase> Updated = delegate { };

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; Updated(this); }
        }

        private int runwayLengthInMeters;
        public int RunwayLengthInMeters
        {
            get { return runwayLengthInMeters; }
            set { runwayLengthInMeters = value; Updated(this); }
        }
    }
}
