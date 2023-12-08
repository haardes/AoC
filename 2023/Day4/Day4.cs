namespace _2023.Day04;

public class Day04
{
    private static readonly string[] input = File.ReadAllLines("../../../Day4/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        foreach (string card in input)
        {
            result += GetCardWorth(card);
        }

        Console.WriteLine(result);
        Assert.Equal(21821, result);
    }

    private static int GetCardWorth(string card)
    {
        int value = 0;
        string[] scratchedNumbers = card.Split(":").Last().Trim().Split("|");
        var winningNumbers = scratchedNumbers.First().Trim().Split(" ").Where(number => number != "").Select(number => int.Parse(number));
        var numbers = scratchedNumbers.Last().Trim().Split(" ").Where(number => number != "").Select(number => int.Parse(number));

        foreach (int num in numbers)
        {
            bool isWinning = winningNumbers.Contains(num);

            if (!isWinning) continue;

            if (value == 0)
            {
                value = 1;
            }
            else
            {
                value *= 2;
            }
        }

        return value;
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;
        Dictionary<int, int> cardCounter = new();

        // Fill dictionary
        foreach (string card in input)
        {
            int cardId = int.Parse(card.Split(":").First().Split(" ").Last());
            cardCounter.Add(cardId, 1);
        }

        foreach (string card in input)
        {
            int cardId = int.Parse(card.Split(":").First().Split(" ").Last());
            int numberOfCards = cardCounter[cardId];
            result += numberOfCards;
            Console.WriteLine($"Number of cards for id {cardId}: {numberOfCards}");

            int wins = GetNumberOfWinningNumbers(card);
            Console.WriteLine($"Winning numbers for id {cardId}: {wins}");

            for (var i = 1; i <= wins; i++)
            {
                if (cardId + 1 == input.Length) break;
                cardCounter[cardId + i] += numberOfCards;
            }
        }

        Console.WriteLine(result);
        Assert.Equal(5539496, result);
    }

    private static int GetNumberOfWinningNumbers(string card)
    {
        string[] scratchedNumbers = card.Split(":").Last().Trim().Split("|");
        var winningNumbers = scratchedNumbers.First().Trim().Split(" ").Where(number => number != "").Select(number => int.Parse(number));
        var numbers = scratchedNumbers.Last().Trim().Split(" ").Where(number => number != "").Select(number => int.Parse(number));

        return numbers.Intersect(winningNumbers).Count();
    }
}