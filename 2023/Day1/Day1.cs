namespace _2023.Day1;

public class Day1
{
    private static readonly string[] input = File.ReadAllLines("../../../Day1/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        foreach (string line in input)
        {
            char? first = null;
            char? second = null;

            foreach (char c in line)
            {
                if (!char.IsDigit(c)) continue;

                first ??= c;
                second = c;
            }

            string digits = first.ToString() + second.ToString();
            result += int.Parse(digits);
        }

        Console.WriteLine(result);
        Assert.Equal(53974, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        List<(string Key, string Value)> pairs = new()
            {
                ("one", "o1e"),
                ("two", "t2o"),
                ("three", "t3e"),
                ("four", "4"),
                ("five", "5e"),
                ("six", "6"),
                ("seven", "7n"),
                ("eight", "e8t"),
                ("nine", "n9e")
            };

        foreach (string l in input)
        {
            string line = l;
            pairs.ForEach(kv => line = line.Replace(kv.Key, kv.Value));

            char? first = null;
            char? second = null;

            foreach (char c in line)
            {
                if (!char.IsDigit(c)) continue;

                first ??= c;
                second = c;
            }

            string digits = first.ToString() + second.ToString();
            result += int.Parse(digits);
        }

        Console.WriteLine(result);
        Assert.Equal(52840, result);
    }
}