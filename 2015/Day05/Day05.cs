using System.Text.RegularExpressions;

namespace _2015.Day05;

public class Day05
{
    private static readonly string[] input = File.ReadAllLines("../../../Day05/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;
        List<string> disallowedCombinations = new() { "ab", "cd", "pq", "xy" };

        foreach (var line in input)
        {
            if (disallowedCombinations.Any(combination => line.Contains(combination))) continue;
            if (!Regex.IsMatch(line, "([\\w])\\1")) continue;
            if (Regex.Matches(line, "[aeiouAEIOU]").Count < 3) continue;

            result++;
        }

        Console.WriteLine(result);
        Assert.Equal(238, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        string repeatingPairRegex = "(..).*\\1";
        string repeatingWithSingleSeparatorRegex = "(.).\\1";

        foreach (var line in input)
        {
            if (!Regex.IsMatch(line, repeatingPairRegex)) continue;
            if (!Regex.IsMatch(line, repeatingWithSingleSeparatorRegex)) continue;

            result++;
        }

        Console.WriteLine(result);
        Assert.Equal(69, result);
    }
}
