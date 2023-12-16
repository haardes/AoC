namespace _2015.Day06;

public class Day06
{
    private static readonly string[] input = File.ReadAllLines("../../../Day06/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        int[] lights = new int[1000000];
        Console.WriteLine("WTF!");

        foreach (string line in input)
        {
            var instructions = line.Split(" ").Reverse();

            int[] endPositions = instructions.First().Split(",").Select(num => int.Parse(num)).ToArray();
            (int X, int Y) end = (endPositions[0], endPositions[1]);

            int[] startPositions = instructions.ElementAt(2).Split(",").Select(num => int.Parse(num)).ToArray();
            (int X, int Y) start = (startPositions[0], startPositions[1]);

            string instruction = instructions.ElementAt(3);

            Console.WriteLine($"{instruction} for {start} to {end}");
            break;
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
