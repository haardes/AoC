using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace _2015.Day04;

public class Day04
{
    private static readonly string input = File.ReadAllText("../../../Day04/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 1;

        var timer = Stopwatch.StartNew();

        while (!BitConverter.ToString(MD5.HashData(Encoding.UTF8.GetBytes($"{input}{result}"))).Replace("-", "").StartsWith("00000"))
        {
            result++;

            if (result % 100000 == 0)
            {
                Console.WriteLine("Still searching...");
                Console.WriteLine(result);
            }

            if (result >= int.MaxValue)
            {
                break;
            }
        }

        timer.Stop();
        Console.WriteLine($"Took {timer.Elapsed.TotalSeconds} seconds to check {result} hashes.");

        Console.WriteLine(result);
        Assert.Equal(254575, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 1;

        var timer = Stopwatch.StartNew();

        while (!BitConverter.ToString(MD5.HashData(Encoding.UTF8.GetBytes($"{input}{result}"))).Replace("-", "").StartsWith("000000"))
        {
            result++;

            if (result % 100000 == 0)
            {
                Console.WriteLine("Still searching...");
                Console.WriteLine(result);
            }

            if (result >= int.MaxValue)
            {
                break;
            }
        }

        timer.Stop();
        Console.WriteLine($"Took {timer.Elapsed.TotalSeconds} seconds to check {result} hashes.");

        Console.WriteLine(result);
        Assert.Equal(1038736, result);
    }
}
