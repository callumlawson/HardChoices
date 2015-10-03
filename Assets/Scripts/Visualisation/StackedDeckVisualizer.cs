using Assets.Scripts.Labels;
using UnityEngine.UI;

namespace Assets.Scripts.Visualisation
{
    public class StackedDeckVisualizer : DeckVisualizer
    {
        public Text CardCount;

        public override void OnDataSourceUpdated(IObservable dataSource)
        {
            var deck = dataSource as Deck;
            if (deck != null)
            {
                CardCount.text = string.Format(deck.Type == DeckType.Draw ? "<color=black>Draw:{0}</color>" : "<color=black>Discard:{0}</color>", deck.Cards.Count);
            }
        }
    }
}