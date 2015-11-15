using System;
using System.Collections.Generic;
using Assets.Scripts.Labels;
using Assets.Scripts.Util.Immutable;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class DeckModel
    {
        public DeckType Type { get; set; }

        public event Action<DeckModel> Updated = delegate { };

        public DeckModel(ImmutableQueue<CardModel> cards, DeckType type)
        {
            Cards = cards;
            Type = type;
        }

        private IImmutableQueue<CardModel> cards;
        public IImmutableQueue<CardModel> Cards
        {
            get { return cards; }
            set
            {
                cards = value;
                Updated(this);
            }
        }
    }
}
