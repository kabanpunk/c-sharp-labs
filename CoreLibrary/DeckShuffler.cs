using System;
using System.Collections.Generic;

namespace CoreLibrary
{
    public class DeckShuffler : IDeckShuffler
    {
        private readonly Random _random = new Random();

        public void Shuffle(List<Card> deck)
        {
            int n = deck.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + _random.Next(n - i);
                (deck[r], deck[i]) = (deck[i], deck[r]);
            }
        }
    }

}