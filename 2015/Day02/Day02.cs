namespace _2015.Day02;

public class Day02
{
    private static readonly string[] input = File.ReadAllLines("../../../Day02/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        foreach (var present in input)
        {
            int[] lengths = present.Split("x").Select(length => int.Parse(length)).ToArray();
            (int l, int w, int h) = (lengths[0], lengths[1], lengths[2]);
            int[] surfaceAreas = new[] { l * w, w * h, h * l };

            int wrappingPaperArea = 2 * surfaceAreas.Aggregate((a, sum) => sum + a) + surfaceAreas.Min();
            result += wrappingPaperArea;
        }

        Console.WriteLine(result);
        Assert.Equal(1598415, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        foreach (var present in input)
        {
            List<int> lengths = present.Split("x").Select(length => int.Parse(length)).ToList();
            (int l, int w, int h) = (lengths[0], lengths[1], lengths[2]);
            lengths.Sort();

            int bowLength = l * w * h;
            int ribbonLength = lengths.Take(2).Select(length => length * 2).Aggregate((a, sum) => a + sum);

            result += bowLength + ribbonLength;
        }

        Console.WriteLine(result);
        Assert.Equal(3812909, result);
    }
}
