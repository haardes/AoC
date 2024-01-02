using System.Text.RegularExpressions;

namespace _2015.Day15;

public class Day15
{
    private static readonly string[] input = File.ReadAllLines("../../../Day15/input.txt");

    [Fact]
    public void PartOne()
    {
        long result = 0;

        Dictionary<string, Ingredient> ingredients = new();

        foreach (string line in input)
        {
            Match match = Regex.Match(line, "(.*?): capacity (-*\\d+?), durability (-*\\d+?), flavor (-*\\d+?), texture (-*\\d+?), calories (-*\\d+?)");

            ingredients.Add(match.Groups[1].Value, new()
            {
                Name = match.Groups[1].Value,
                Capacity = int.Parse(match.Groups[2].Value),
                Durability = int.Parse(match.Groups[3].Value),
                Flavour = int.Parse(match.Groups[4].Value),
                Texture = int.Parse(match.Groups[5].Value),
                Calories = int.Parse(match.Groups[6].Value)
            });
        }

        for (var sprinkles = 0; sprinkles < 100; sprinkles++)
        {
            for (var butterscotch = 0; butterscotch <= 100 - sprinkles; butterscotch++)
            {
                for (var chocolate = 0; chocolate <= 100 - sprinkles - butterscotch; chocolate++)
                {
                    var candy = 100 - sprinkles - butterscotch - chocolate;
                    long capacityScore = sprinkles * ingredients["Sprinkles"].Capacity + butterscotch * ingredients["Butterscotch"].Capacity + chocolate * ingredients["Chocolate"].Capacity + candy * ingredients["Candy"].Capacity;
                    long durabilityScore = sprinkles * ingredients["Sprinkles"].Durability + butterscotch * ingredients["Butterscotch"].Durability + chocolate * ingredients["Chocolate"].Durability + candy * ingredients["Candy"].Durability;
                    long flavourScore = sprinkles * ingredients["Sprinkles"].Flavour + butterscotch * ingredients["Butterscotch"].Flavour + chocolate * ingredients["Chocolate"].Flavour + candy * ingredients["Candy"].Flavour;
                    long textureScore = sprinkles * ingredients["Sprinkles"].Texture + butterscotch * ingredients["Butterscotch"].Texture + chocolate * ingredients["Chocolate"].Texture + candy * ingredients["Candy"].Texture;

                    if (capacityScore <= 0 || durabilityScore <= 0 || flavourScore <= 0 || textureScore <= 0)
                    {
                        continue;
                    }

                    long totalScore = capacityScore * durabilityScore * flavourScore * textureScore;

                    if (totalScore > result)
                    {
                        result = totalScore;
                    }
                }
            }
        }

        Console.WriteLine(result);
        Assert.Equal(21367368, result);
    }

    [Fact]
    public void PartTwo()
    {
        long result = 0;

        Dictionary<string, Ingredient> ingredients = new();

        foreach (string line in input)
        {
            Match match = Regex.Match(line, "(.*?): capacity (-*\\d+?), durability (-*\\d+?), flavor (-*\\d+?), texture (-*\\d+?), calories (-*\\d+?)");

            ingredients.Add(match.Groups[1].Value, new()
            {
                Name = match.Groups[1].Value,
                Capacity = int.Parse(match.Groups[2].Value),
                Durability = int.Parse(match.Groups[3].Value),
                Flavour = int.Parse(match.Groups[4].Value),
                Texture = int.Parse(match.Groups[5].Value),
                Calories = int.Parse(match.Groups[6].Value)
            });
        }

        for (var sprinkles = 0; sprinkles < 100; sprinkles++)
        {
            for (var butterscotch = 0; butterscotch <= 100 - sprinkles; butterscotch++)
            {
                for (var chocolate = 0; chocolate <= 100 - sprinkles - butterscotch; chocolate++)
                {
                    var candy = 100 - sprinkles - butterscotch - chocolate;
                    int calories = sprinkles * ingredients["Sprinkles"].Calories + butterscotch * ingredients["Butterscotch"].Calories + chocolate * ingredients["Chocolate"].Calories + candy * ingredients["Candy"].Calories;
                    if (calories != 500)
                    {
                        continue;
                    }

                    long capacityScore = sprinkles * ingredients["Sprinkles"].Capacity + butterscotch * ingredients["Butterscotch"].Capacity + chocolate * ingredients["Chocolate"].Capacity + candy * ingredients["Candy"].Capacity;
                    long durabilityScore = sprinkles * ingredients["Sprinkles"].Durability + butterscotch * ingredients["Butterscotch"].Durability + chocolate * ingredients["Chocolate"].Durability + candy * ingredients["Candy"].Durability;
                    long flavourScore = sprinkles * ingredients["Sprinkles"].Flavour + butterscotch * ingredients["Butterscotch"].Flavour + chocolate * ingredients["Chocolate"].Flavour + candy * ingredients["Candy"].Flavour;
                    long textureScore = sprinkles * ingredients["Sprinkles"].Texture + butterscotch * ingredients["Butterscotch"].Texture + chocolate * ingredients["Chocolate"].Texture + candy * ingredients["Candy"].Texture;

                    if (capacityScore <= 0 || durabilityScore <= 0 || flavourScore <= 0 || textureScore <= 0)
                    {
                        continue;
                    }

                    long totalScore = capacityScore * durabilityScore * flavourScore * textureScore;

                    if (totalScore > result)
                    {
                        result = totalScore;
                    }
                }
            }
        }

        Console.WriteLine(result);
        Assert.Equal(1766400, result);
    }
}

public class Ingredient
{
    public string? Name { get; set; }
    public int Capacity { get; set; }
    public int Durability { get; set; }
    public int Flavour { get; set; }
    public int Texture { get; set; }
    public int Calories { get; set; }

    public long GetScore(int amount)
    {
        var score = Capacity * amount +
            Durability * amount +
            Flavour * amount +
            Texture * amount;

        return score < 0 ? 0 : score;
    }
}
