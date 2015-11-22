using System;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Agent : IObjectModel, IObservable<Agent>
    {
        public event Action<Agent> Updated = delegate { };

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; Updated(this); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; Updated(this); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; Updated(this); }
        }

        private int motivation;
        public int Motivation
        {
            get { return motivation; }
            set { motivation = value; Updated(this); }
        }
    }
}
