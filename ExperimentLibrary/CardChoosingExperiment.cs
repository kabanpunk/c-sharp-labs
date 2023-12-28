using System;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary;
using StrategiesLibrary;

namespace ExperimentLibrary
{
    public class CardChoosingExperiment
    {
        private readonly IDeckShuffler _shuffler;

        public CardChoosingExperiment(IDeckShuffler shuffler)
        {
            _shuffler = shuffler;
        }

        public bool ConductExperiment(IPartnerStrategy strategy1, IPartnerStrategy strategy2)
        {
            // Создаем и перемешиваем колоду
            List<Card> deck = CreateDeck();
            _shuffler.Shuffle(deck);

            // Делим колоду на две части
            var halfDeckSize = deck.Count / 2;
            var half1 = deck.Take(halfDeckSize).ToList();
            var half2 = deck.Skip(halfDeckSize).ToList();

            // Применяем стратегии
            var index1 = strategy1.ChooseCard(half1);
            var index2 = strategy2.ChooseCard(half2);

            // Убедиться, что индексы находятся в допустимых пределах
            if (index1 < 0 || index1 >= half1.Count || index2 < 0 || index2 >= half2.Count)
            {
                throw new InvalidOperationException("Стратегия выбрала недопустимый индекс карты.");
            }

            // Проверяем, совпадают ли цвета выбранных карт
            return half2[index1].Color == half1[index2].Color;
        }


        private List<Card> CreateDeck()
        {
            var deck = new List<Card>();
            int totalCards = 36; // Общее количество карт в колоде
            int halfDeck = totalCards / 2; // Количество карт одного цвета

            // Добавление красных карт
            for (int i = 1; i <= halfDeck; i++)
            {
                deck.Add(new Card(Card.CardColor.Red, i));
            }

            // Добавление черных карт
            for (int i = 1; i <= halfDeck; i++)
            {
                deck.Add(new Card(Card.CardColor.Black, i));
            }

            return deck;
        }

    }
}
