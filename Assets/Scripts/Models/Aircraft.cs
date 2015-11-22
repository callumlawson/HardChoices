using System;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Aircraft : IObjectModel, IObservable<Aircraft>
    {
        public event Action<Aircraft> Updated = delegate { };

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; Updated(this); }
        }

        private int acceleration;
        public int Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; Updated(this); }
        }
    }
}
