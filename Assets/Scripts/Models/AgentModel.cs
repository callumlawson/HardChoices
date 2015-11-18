using System;
using Assets.Scripts.Util;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class AgentModel : ObjectModel, IObservable<AgentModel>
    {
        public int Motivation { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }

        public event Action<AgentModel> Updated = delegate { };

        public AgentModel(){}

        public AgentModel(string name, string description, int age, int motivation)
        {
            Motivation = motivation;
            Description = description;
            Age = age;
            Name = name;
        }
    }
}
