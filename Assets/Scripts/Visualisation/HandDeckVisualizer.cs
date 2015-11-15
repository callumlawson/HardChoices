using System;
using System.Collections.Generic;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Visualisation
{
    public class HandDeckVisualizer : DeckVisualizer
    {
        public GameObject CardPrefab;

        private List<GameObject> Cards;
        private RectTransform RectTransform;

        public void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
            Cards = new List<GameObject>();
        }

        public override void OnDataSourceUpdated(DeckModel deck)
        {
            ClearCards();
            CreateCards(deck);
            PositionCards();
        }

        private void ClearCards()
        {
            foreach (var card in Cards)
            {
                Destroy(card);
            }
            Cards.Clear();
        }

        private void CreateCards(DeckModel deck)
        {
            foreach (var card in deck.Cards)
            {
                var cardGameObject = Instantiate(CardPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                if (cardGameObject)
                {
                    cardGameObject.GetComponent<CardVisualizer>().Init(card);
                    Cards.Add(cardGameObject);
                }
                else
                {
                    Debug.LogError("You need to set the CardPrefab on the HandDeckVisualizer");
                }
            }
        }

        private void PositionCards()
        {
            for (var cardIndex = 0; cardIndex < Cards.Count; cardIndex++)
            {
                var card = Cards[cardIndex];
                card.GetComponent<CardVisualizer>().SetSortingIndex(cardIndex);
                card.transform.SetParent(transform, false);
                card.transform.localPosition = GetCardPosition(Cards.Count, cardIndex);
            }
        }

        private Vector3 GetCardPosition(int cardCount, int cardIndex)
        {
            var xStep = RectTransform.rect.width/Math.Max(Cards.Count, 4);
            var xOffset = xStep * cardIndex;
            var leftShift = (xStep*cardCount)/2 - 50;
            return new Vector3(xOffset - leftShift, 80, 0);
        }
    }
}
