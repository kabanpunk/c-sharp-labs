using System.Collections.Generic;

namespace CoreLibrary
{
    public interface IDeckShuffler
    {
        void Shuffle(List<Card> deck);
    } 
}