using System.Collections.Generic;
using CoreLibrary;

namespace StrategiesLibrary
{
    public interface IPartnerStrategy
    {
        int ChooseCard(List<Card> halfDeck);
    }
}