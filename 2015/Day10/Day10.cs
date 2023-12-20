using System.Text.RegularExpressions;

namespace _2015.Day10;

public class Day10
{
    private static readonly string[] input = File.ReadAllLines("../../../Day10/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;
        string permutation = input.First();

        for (var i = 0; i < 40; i++)
        {
            int count = 0;
            char? prevC = null;
            string temp = "";

            for (var j = 0; j < permutation.Length; j++)
            {
                char c = permutation[j];

                if (prevC == null)
                {
                    prevC = c;
                    count++;
                    continue;
                }

                if (c != prevC)
                {
                    temp += $"{count}{prevC}";
                    count = 1;
                    prevC = c;
                    continue;
                }

                count++;
            }

            temp += $"{count}{prevC}";
            permutation = temp;

            Console.WriteLine($"Length of permutation {i + 1} = {permutation.Length}");
        }

        result = permutation.Length;

        Console.WriteLine(result);
        Assert.Equal(329356, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;
        string input = Day10.input.First();

        for (var i = 0; i < 50; i++)
        {
            Console.WriteLine(i + 1);
            string next = "";
            var matches = Regex.Matches(input, "((.)\\2*)");
            next += string.Join("", matches.Select(match => $"{match.Length}{match.Groups[2]}"));
            input = next;
        }

        result = input.Length;

        Console.WriteLine(result);
        Assert.Equal(4666278, result);
    }
}
