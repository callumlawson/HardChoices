using System;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Agent : ObjectModel<Agent>
    {
        private int description;
        public int Description
        {
            get { return description; }
            set { description = value; Update(); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; Update(); }
        }

        private int motivation;
        public int Motivation
        {
            get { return motivation; }
            set { motivation = value; Update(); }
        }
    }
}
