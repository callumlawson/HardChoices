using System;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Labels;

namespace Assets.Data
{
    [Serializable]
    public static class InitalConditions
    {
        private static readonly List<Card> StarterCards = new List<Card>
        {
            Cards.FastAdvance,
            Cards.FastAdvance,
            Cards.KillLaKill,
            Cards.CorporateReshuffle,
            Cards.KillLaKill,
            Cards.FastAdvance,
            Cards.FastAdvance,
            Cards.KillLaKill,
            Cards.CorporateReshuffle,
            Cards.KillLaKill,
            Cards.FastAdvance,
            Cards.FastAdvance,
            Cards.KillLaKill,
            Cards.CorporateReshuffle,
            Cards.KillLaKill
        };

        public static readonly Deck HandDeck = new Deck(new Queue<Card>(), DeckType.Hand);
        public static readonly Deck DiscardDeck = new Deck(new Queue<Card>(), DeckType.Discard);
        public static readonly Deck DrawDeck = new Deck(new Queue<Card>(StarterCards), DeckType.Draw);
    }
}