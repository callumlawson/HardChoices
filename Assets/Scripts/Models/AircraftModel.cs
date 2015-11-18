using System;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class AircraftModel : ObjectModel, IObservable<AircraftModel>
    {
        public string Name { get; set; }
        public float Acceleration { get; set; }

        public event Action<AircraftModel> Updated = delegate { };

        public AircraftModel(){}

        public AircraftModel(string name, float acceleration)
        {
            Name = name;
            Acceleration = acceleration;
        }
    }
}
