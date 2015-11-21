using System;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Aircraft : ObjectModel<Aircraft>
    {
        private int acceleration;
        public int Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; Update(); }
        }
    }
}
