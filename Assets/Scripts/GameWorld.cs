using Assets.Data;
using Assets.Scripts.Controller;
using Assets.Scripts.Models;
using Assets.Scripts.Util;
using Assets.Scripts.Visualisation;
using UnityEngine;

namespace Assets.Scripts
{
    class GameWorld : CustomMonoBehaviour
    {
        //Setup in editor
        public GameObject UI;
        public GameObject Card;
        public StackedDeckVisualizer DiscardVisualizer;
        public HandDeckVisualizer HandVisualizer;
        public StackedDeckVisualizer DrawVisualizer;

        public static GameWorld Instance;

        private DeckController DiscardDeckController;
        private DeckController HandDeckController;
        private DeckController DrawDeckController;

        public void Start()
        {
            Instance = this;

            DiscardDeckController = InitDeck(InitalConditions.DiscardDeck, DiscardVisualizer);
            HandDeckController = InitDeck(InitalConditions.HandDeck, HandVisualizer);
            DrawDeckController = InitDeck(InitalConditions.DrawDeck, DrawVisualizer);
        }

        public void CardActivated(CardModel card)
        {
           Debug.Log("Card clicked! " + card); 
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                DrawDeckController.Draw(HandDeckController);
            }
        }

        private DeckController InitDeck(DeckModel deckToClone, DeckVisualizer deckVisualizer)
        {
            var deckModel = Utils.DeepClone(deckToClone);
            deckVisualizer.Init(deckModel);
            return new DeckController(deckModel);
        }
    }
}
