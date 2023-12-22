using System.Text.RegularExpressions;

namespace _2015.Day15;

public class Day15
{
    private static readonly string[] input = File.ReadAllLines("../../../Day15/test_input.txt");

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

        foreach (var kv in ingredients)
        {
            Console.WriteLine($"Cap: {kv.Value.Capacity}, dur: {kv.Value.Durability}, flav: {kv.Value.Flavour}, text: {kv.Value.Texture}");
        }

        // SUPER-NAIVE solution because it seemed fun to try
        var count = 0;
        var allCount = 0;

        for (var sprinkles = 0; sprinkles < 100; sprinkles++)
        {
            var butterscotch = 100 - sprinkles;
            /* for (var butterscotch = 0; butterscotch < 100 - sprinkles; butterscotch++)
            { */
            count++;
            /*  for (var chocolate = 0; chocolate < 100 - sprinkles - butterscotch; chocolate++)
             {
                 var candy = 100 - sprinkles - butterscotch - chocolate; */
            if (sprinkles == 56) Console.WriteLine("HELLO!");

            var capacities = ingredients.ToList().Select(i => i.Value.Capacity).ToList();
            var capScore = capacities[0] * butterscotch + capacities[1] * sprinkles;

            var durabilities = ingredients.ToList().Select(i => i.Value.Durability).ToList();
            var durScore = durabilities[0] * butterscotch + durabilities[1] * sprinkles;

            var flavours = ingredients.ToList().Select(i => i.Value.Flavour).ToList();
            var flavScore = flavours[0] * butterscotch + flavours[1] * sprinkles;

            var textures = ingredients.ToList().Select(i => i.Value.Texture).ToList();
            var textScore = textures[0] * butterscotch + textures[1] * sprinkles;

            /* long capScore = ingredients.GetValueOrDefault("Sprinkles")!.Capacity * sprinkles +
                            ingredients.GetValueOrDefault("Butterscotch")!.Capacity * butterscotch +
                            ingredients.GetValueOrDefault("Chocolate")!.Capacity * chocolate +
                            ingredients.GetValueOrDefault("Candy")!.Capacity * candy;

            long durScore = ingredients.GetValueOrDefault("Sprinkles")!.Durability * sprinkles +
                            ingredients.GetValueOrDefault("Butterscotch")!.Durability * butterscotch +
                            ingredients.GetValueOrDefault("Chocolate")!.Durability * chocolate +
                            ingredients.GetValueOrDefault("Candy")!.Durability * candy;

            long flavScore = ingredients.GetValueOrDefault("Sprinkles")!.Flavour * sprinkles +
                            ingredients.GetValueOrDefault("Butterscotch")!.Flavour * butterscotch +
                            ingredients.GetValueOrDefault("Chocolate")!.Flavour * chocolate +
                            ingredients.GetValueOrDefault("Candy")!.Flavour * candy;

            long textScore = ingredients.GetValueOrDefault("Sprinkles")!.Texture * sprinkles +
                            ingredients.GetValueOrDefault("Butterscotch")!.Texture * butterscotch +
                            ingredients.GetValueOrDefault("Chocolate")!.Texture * chocolate +
                            ingredients.GetValueOrDefault("Candy")!.Texture * candy; */

            long totalScore = capScore * durScore * flavScore * textScore;

            if (totalScore > result) result = totalScore;

        }

        Console.WriteLine(result);
        Assert.Equal(-1, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        Console.WriteLine(result);
        Assert.Equal(-1, result);
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
