using Assets.Scripts.Util;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Visualisation
{
    public class CardVisualizer : CustomMonoBehaviour, IObserver, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Text CardTitle;
        public Text CardDescription;

        public bool BeingMousedOver;

        private Canvas Canvas;
        private Card Card;
        private int SortOrder;

        public void Init(Card card)
        {
            Canvas = GetComponent<Canvas>();
            Card = card;
            card.Updated += OnDataSourceUpdated;
            OnDataSourceUpdated(card);
        }

        public void SetSortingIndex(int index)
        {
            SortOrder = 100 - index;
            Canvas.sortingOrder = SortOrder;
        }

        public void OnDataSourceUpdated(IObservable dataSource)
        {
            var card = dataSource as Card;
            if (card != null)
            {
                CardTitle.text = card.Title;
                CardDescription.text = card.Description;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            BeingMousedOver = true;
            transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 1.0f);
            Canvas.sortingOrder = 200;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            BeingMousedOver = false;
            transform.DOScale(new Vector3(1, 1, 1), 1.0f);
            Canvas.sortingOrder = SortOrder;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Player.Instance.PlayCard(Card);
        }
    }
}
