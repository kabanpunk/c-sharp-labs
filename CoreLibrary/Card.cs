namespace CoreLibrary
{
    public class Card
    {
        public enum CardColor
        {
            Red,
            Black
        }

        public CardColor Color { get; private set; }
        public int Value { get; private set; }

        public Card(CardColor color, int value)
        {
            Color = color;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Card otherCard = (Card)obj;
            return Color == otherCard.Color && Value == otherCard.Value;
        }

        public override int GetHashCode()
        {
            return Color.GetHashCode() ^ Value.GetHashCode();
        }

        public static bool operator ==(Card card1, Card card2)
        {
            return card1?.Equals(card2) ?? false;
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }
    }
}