using System.Text.RegularExpressions;

namespace _2015.Day14;

public class Day14
{
    private static readonly string[] input = File.ReadAllLines("../../../Day14/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        List<Reindeer> reindeers = new();

        foreach (string line in input)
        {
            Match match = Regex.Match(line, "(.*?) can fly (\\d*) km/s for (\\d*) seconds, but then must rest for (\\d*) seconds.");

            reindeers.Add(new()
            {
                Name = match.Groups[1].Value,
                Speed = int.Parse(match.Groups[2].Value),
                Endurance = int.Parse(match.Groups[3].Value),
                RestTime = int.Parse(match.Groups[4].Value)
            });
        }

        int seconds = 2503;

        var distances = reindeers.Select(reindeer =>
        {
            decimal cycleLength = reindeer.Endurance + reindeer.RestTime;
            var fullCycles = Math.Floor(seconds / cycleLength);
            var distance = fullCycles * reindeer.Endurance * reindeer.Speed;
            var remainder = seconds % cycleLength;
            distance += remainder > reindeer.Endurance ? reindeer.Endurance * reindeer.Speed : remainder * reindeer.Speed;
            Console.WriteLine($"{reindeer.Name}: {distance}");
            return distance;
        });

        result = (int)distances.Max();

        Console.WriteLine(result);
        Assert.Equal(2696, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        List<Reindeer> reindeers = new();

        foreach (string line in input)
        {
            Match match = Regex.Match(line, "(.*?) can fly (\\d*) km/s for (\\d*) seconds, but then must rest for (\\d*) seconds.");

            reindeers.Add(new()
            {
                Name = match.Groups[1].Value,
                Speed = int.Parse(match.Groups[2].Value),
                Endurance = int.Parse(match.Groups[3].Value),
                RestTime = int.Parse(match.Groups[4].Value)
            });
        }

        int seconds = 2503;

        for (var second = 0; second < seconds; second++)
        {
            reindeers.ForEach(reindeer =>
            {
                decimal cycleLength = reindeer.Endurance + reindeer.RestTime;
                if (second % cycleLength < reindeer.Endurance)
                {
                    reindeer.Distance += reindeer.Speed;
                }
            });

            var leadingDistance = reindeers.Max(reindeer => reindeer.Distance);
            reindeers.FindAll(reindeer => reindeer.Distance == leadingDistance).ForEach(reindeer => reindeer.Points++);
        }

        result = reindeers.Max(reindeer => reindeer.Points);

        Console.WriteLine(result);
        Assert.Equal(1084, result);
    }
}

public class Reindeer
{
    public string Name { get; set; }
    public int Speed { get; set; }
    public int Endurance { get; set; }
    public int RestTime { get; set; }
    public int Distance { get; set; } = 0;
    public int Points { get; set; } = 0;
}
