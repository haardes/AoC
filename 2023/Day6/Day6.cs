namespace _2023.Day06;

public class Day06
{
    private static readonly string[] input = File.ReadAllLines("../../../Day6/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 1;

        var times = input[0].Split(":")[1].Split(" ").Where(substr => substr != "").Select(str => int.Parse(str.Trim()));
        var distances = input[1].Split(":")[1].Split(" ").Where(substr => substr != "").Select(str => int.Parse(str.Trim()));

        var races = times.Zip(distances);

        foreach (var (time, distanceToBeat) in races)
        {
            var winningRuns = 0;

            for (var i = 0; i < time; i++)
            {
                var accumulatedSpeed = i;
                var timeToTravel = time - i;
                var distanceTraveled = accumulatedSpeed * timeToTravel;

                if (distanceTraveled > distanceToBeat) winningRuns++;
            }

            result *= winningRuns;
        }

        Console.WriteLine(result);
        Assert.Equal(4568778, result);
    }

    [Fact]
    public void PartTwo()
    {
        long result = 1;

        var time = long.Parse(string.Join("", input[0].Split(":")[1].Split(" ").Where(substr => substr != "")));
        var distanceToBeat = long.Parse(string.Join("", input[1].Split(":")[1].Split(" ").Where(substr => substr != "")));


        var winningRuns = 0;

        for (var i = 0; i < time; i++)
        {
            var accumulatedSpeed = i;
            var timeToTravel = time - i;
            var distanceTraveled = accumulatedSpeed * timeToTravel;

            if (distanceTraveled > distanceToBeat) winningRuns++;
        }

        result *= winningRuns;

        Console.WriteLine(result);
        Assert.Equal(28973936, result);
    }
}
