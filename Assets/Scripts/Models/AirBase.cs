using System;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class AirBase : ObjectModel<AirBase>
    {
        private int runwayLengthInMeters;
        public int RunwayLengthInMeters
        {
            get { return runwayLengthInMeters; }
            set { runwayLengthInMeters = value; Update(); }
        }
    }
}
