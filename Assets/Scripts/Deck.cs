using System;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Labels;

[Serializable]
public class Deck : IObservable
{
    public Queue<Card> Cards { get; private set; }
    public DeckType Type { get; private set; }

    public event Action<IObservable> Updated = delegate {};

    public Deck(Queue<Card> cards, DeckType type)
    {
        Cards = cards;
        Type = type;
    }

    public Card RemoveCard()
    {
        var card = Cards.Dequeue();
        Updated(this);
        return card;
    }

    public void AddCard(Card card)
    {
        Cards.Enqueue(card);
        Updated(this);
    }
}