using System;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class AirBaseModel : ObjectModel, IObservable<AirBaseModel>
    {
        public string Name { get; set; }
        public int RunwayLengthInMeters { get; set; }

        public event Action<AirBaseModel> Updated = delegate { };

        public AirBaseModel(){}

        public AirBaseModel(string name, int runwayLengthInMeters)
        {
            Name = name;
            RunwayLengthInMeters = runwayLengthInMeters;
        }
    }
}
