namespace _2023.Day07;

public class Day07
{
    private static readonly string[] input = File.ReadAllLines("../../../Day7/input.txt");

    public static readonly Dictionary<char, int> CardValues = new() {
        {'A', 14},
        {'K', 13},
        {'Q', 12},
        {'J', 11},
        {'T', 10},
        {'9', 9},
        {'8', 8},
        {'7', 7},
        {'6', 6},
        {'5', 5},
        {'4', 4},
        {'3', 3},
        {'2', 2},
    };

    public static readonly Dictionary<string, int> TypeValues = new() {
        {"FIVE", 7},
        {"FOUR", 6},
        {"HOUSE", 5},
        {"THREE", 4},
        {"TWO", 3},
        {"ONE", 2},
        {"HIGH", 1}
    };

    [Fact]
    public void PartOne()
    {
        int result = 0;

        List<Hand> hands = new();

        foreach (var round in input)
        {
            hands.Add(new(round.Split(" ")[0], round.Split(" ")[1]));
        }

        hands.Sort();

        for (var i = 0; i < hands.Count; i++)
        {
            var hand = hands[i];
            result += hand.Bid * (i + 1);
        }

        Console.WriteLine(result);
        Assert.Equal(250951660, result);
    }

    private class Hand : IComparable
    {
        public readonly string Cards;
        public readonly int Bid;

        public Hand(string cards, string bid)
        {
            Cards = cards;
            Bid = int.Parse(bid.Trim());
        }

        public int CompareTo(object? obj)
        {
            if (obj!.GetType() != GetType())
            {
                return 0;
            }

            var other = (Hand)obj;

            int score = ScoreHand(Cards);
            int otherScore = ScoreHand(other.Cards);

            if (score != otherScore)
            {
                return score - otherScore;
            }

            return CompareEqualHands(Cards, other.Cards);

        }

        private static int CompareEqualHands(string cards, string otherCards)
        {
            for (var i = 0; i < cards.Length; i++)
            {
                int thisVal = CardValues[cards[i]];
                int otherVal = CardValues[otherCards[i]];

                if (thisVal == otherVal) continue;
                return thisVal - otherVal;
            }

            return 0;
        }

        private static int ScoreHand(string cards)
        {
            var counts = CardValues.Select(cardValue =>
            {
                var Card = cardValue.Key;
                var Count = cards.Count(c => c == Card);
                return (Card, Count);
            });

            if (counts.Any(count => count.Count == 5)) return TypeValues["FIVE"];
            if (counts.Any(count => count.Count == 4)) return TypeValues["FOUR"];
            if (counts.Any(count => count.Count == 3) && counts.Any(count => count.Count == 2)) return TypeValues["HOUSE"];
            if (counts.Any(count => count.Count == 3)) return TypeValues["THREE"];
            if (counts.Count(count => count.Count == 2) == 2) return TypeValues["TWO"];
            if (counts.Any(count => count.Count == 2)) return TypeValues["ONE"];
            Console.WriteLine(cards);
            return TypeValues["HIGH"];
        }
    }

    public static readonly Dictionary<char, int> JokerCardValues = new() {
        {'A', 14},
        {'K', 13},
        {'Q', 12},
        {'J', 1},
        {'T', 10},
        {'9', 9},
        {'8', 8},
        {'7', 7},
        {'6', 6},
        {'5', 5},
        {'4', 4},
        {'3', 3},
        {'2', 2}
    };

    private class JokerHand : IComparable
    {
        public readonly string Cards;
        public readonly int Bid;

        public JokerHand(string cards, string bid)
        {
            Cards = cards;
            Bid = int.Parse(bid.Trim());
        }

        public int CompareTo(object? obj)
        {
            if (obj!.GetType() != GetType())
            {
                return 0;
            }

            var other = (JokerHand)obj;

            int score = ScoreHand(Cards);
            int otherScore = ScoreHand(other.Cards);

            if (score != otherScore)
            {
                return score - otherScore;
            }

            return CompareEqualHands(Cards, other.Cards);

        }

        private static int CompareEqualHands(string cards, string otherCards)
        {
            for (var i = 0; i < cards.Length; i++)
            {
                int thisVal = JokerCardValues[cards[i]];
                int otherVal = JokerCardValues[otherCards[i]];

                if (thisVal == otherVal) continue;
                return thisVal - otherVal;
            }

            return 0;
        }

        public static int ScoreHand(string cards)
        {
            var jokerCount = JokerCardValues.Where(cardValue => cardValue.Key == 'J').Select(cardValue => cards.Count(c => c == cardValue.Key)).First();
            var counts = JokerCardValues.Select(cardValue =>
            {
                var Card = cardValue.Key;
                var Count = cards.Count(c => c == Card);

                return (Card, Count);
            });

            if (counts.Any(count => count.Count + jokerCount == 5))
            {
                return TypeValues["FIVE"];
            }

            if (counts.Any(count => count.Count + jokerCount == 4))
            {
                return TypeValues["FOUR"];
            }

            if (counts.Any(count => count.Count == 3) && counts.Any(count => count.Count == 2))
            {
                return TypeValues["HOUSE"];
            }

            if (counts.Count(count => count.Count + jokerCount == 3) >= 2)
            {
                return TypeValues["HOUSE"];
            }

            if (counts.Any(count => count.Count + jokerCount == 3))
            {
                return TypeValues["THREE"];
            }

            if (counts.Count(count => count.Count + jokerCount == 2) == 2)
            {
                return TypeValues["TWO"];
            }

            if (counts.Any(count => count.Count + jokerCount == 2)) return TypeValues["ONE"];
            return TypeValues["HIGH"];
        }
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        List<JokerHand> hands = new();

        foreach (var round in input)
        {
            hands.Add(new(round.Split(" ")[0], round.Split(" ")[1]));
        }

        hands.Sort();

        //hands.ForEach(hand => Console.WriteLine($"{hand.Cards} {hand.Bid}"));

        for (var i = 0; i < hands.Count; i++)
        {
            var hand = hands[i];
            result += hand.Bid * (i + 1);
        }

        Console.WriteLine(result);
        Assert.Equal(-1, result);
    }
}
