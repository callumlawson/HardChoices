using System.Linq;
using Assets.Scripts.Labels;
using Assets.Scripts.Models;
using UnityEngine.UI;

namespace Assets.Scripts.Visualisation
{
    public class StackedDeckVisualizer : DeckVisualizer
    {
        public Text CardCount;

        public override void OnDataSourceUpdated(DeckModel deck)
        {
            if (deck != null)
            {
                CardCount.text = string.Format(deck.Type == DeckType.Draw ? "<color=black>Draw:{0}</color>" : "<color=black>Discard:{0}</color>", deck.Cards.Count());
            }
        }
    }
}