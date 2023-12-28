using System.Collections.Generic;
using CoreLibrary;

namespace StrategiesLibrary
{
    public class SimpleStrategy : IPartnerStrategy
    {
        public int ChooseCard(List<Card> halfDeck)
        {
            // Простая стратегия: всегда выбираем первую карту
            return 0;
        } 
    }
}