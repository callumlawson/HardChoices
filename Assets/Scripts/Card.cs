using System;

namespace Assets.Scripts
{
    [Serializable]
    public class Card : IObservable
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public event Action<IObservable> Updated = delegate { };

        public Card(string title, string description)
        {
            Description = description;
            Title = title;
        }
    }
}
