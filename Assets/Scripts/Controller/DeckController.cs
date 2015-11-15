using Assets.Scripts.Models;

namespace Assets.Scripts.Controller
{
    internal class DeckController
    {
        private readonly DeckModel Deck;

        public DeckController(DeckModel deck)
        {
            Deck = deck;
        }

        public void Draw(DeckController deckToDrawTo)
        {
            deckToDrawTo.AddCard(RemoveCard());
        }

        public CardModel RemoveCard()
        {
            CardModel card;
            Deck.Cards = Deck.Cards.Dequeue(out card);
            return card;
        }

        public void AddCard(CardModel card)
        {
            Deck.Cards = Deck.Cards.Enqueue(card);
        }
    }
}