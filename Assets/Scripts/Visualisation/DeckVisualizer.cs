using Assets.Scripts.Models;
using Assets.Scripts.Util;

namespace Assets.Scripts.Visualisation
{
    public abstract class DeckVisualizer : CustomMonoBehaviour, IObserver<DeckModel>
    {
        public void Init(DeckModel deck)
        {
            deck.Updated += OnDataSourceUpdated;
            OnDataSourceUpdated(deck);
        }

        public abstract void OnDataSourceUpdated(DeckModel dataSource);
    }
}
