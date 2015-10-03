using Assets.Scripts.Util;

namespace Assets.Scripts.Visualisation
{
    public abstract class DeckVisualizer : CustomMonoBehaviour, IObserver
    {
        public void Init(Deck deck)
        {
            deck.Updated += OnDataSourceUpdated;
            OnDataSourceUpdated(deck);
        }

        public abstract void OnDataSourceUpdated(IObservable dataSource);
    }
}
