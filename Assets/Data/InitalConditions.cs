using System;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Labels;
using Assets.Scripts.Models;
using Assets.Scripts.Util.Immutable;

namespace Assets.Data
{
    [Serializable]
    public static class InitalConditions
    {
        private static readonly List<CardModel> StarterCards = new List<CardModel>
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

        public static readonly DeckModel HandDeck = new DeckModel(new ImmutableQueue<CardModel>(), DeckType.Hand);
        public static readonly DeckModel DiscardDeck = new DeckModel(new ImmutableQueue<CardModel>(), DeckType.Discard);
        public static readonly DeckModel DrawDeck = new DeckModel(ImmutableQueue.Create<CardModel>(StarterCards), DeckType.Draw);
    }
}