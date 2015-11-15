using System;
using Assets.Scripts.Util;

namespace Assets.Scripts
{
    [Serializable]
    public class CardModel : IObservable<CardModel>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public event Action<CardModel> Updated = delegate { };

        public CardModel(string title, string description)
        {
            Description = description;
            Title = title;
        }
    }
}
