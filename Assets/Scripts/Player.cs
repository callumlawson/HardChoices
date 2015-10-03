using Assets.Data;
using Assets.Scripts.Util;
using Assets.Scripts.Visualisation;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public GameObject UI;
        public GameObject Card;

        private Deck DiscardDeck;
        private Deck HandDeck;
        private Deck DrawDeck;

        public StackedDeckVisualizer DiscardVisualizer;
        public HandDeckVisualizer HandVisualizer;
        public StackedDeckVisualizer DrawVisualizer;

        public static Player Instance;

        // Use this for initialization
        void Start ()
        {
            Instance = this;

            DiscardDeck = Utils.DeepClone(InitalConditions.DiscardDeck);
            HandDeck = Utils.DeepClone(InitalConditions.HandDeck);
            DrawDeck = Utils.DeepClone(InitalConditions.DrawDeck);

            DiscardVisualizer.Init(DiscardDeck);
            HandVisualizer.Init(HandDeck);
            DrawVisualizer.Init(DrawDeck);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Draw();
            }
        }

        public void Draw()
        {
            HandDeck.AddCard(DrawDeck.RemoveCard());
        }

        //TODO: Atually use the selected card!
        public void PlayCard(Card card)
        {
            DiscardDeck.AddCard(HandDeck.RemoveCard());
        }
    }
}
