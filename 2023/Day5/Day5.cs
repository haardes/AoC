namespace _2023.Day05;

public class Day05
{
    private static readonly string input = File.ReadAllText("../../../Day5/input.txt");

    [Fact]
    public void PartOne()
    {
        long result = 0;

        List<long> seeds = new();
        List<(long destinationStart, long sourceStart, long length)> seedToSoilRanges = new();
        List<(long destinationStart, long sourceStart, long length)> soilToFertilizerRanges = new();
        List<(long destinationStart, long sourceStart, long length)> fertilizerToWaterRanges = new();
        List<(long destinationStart, long sourceStart, long length)> waterToLightRanges = new();
        List<(long destinationStart, long sourceStart, long length)> lightToTemperatureRanges = new();
        List<(long destinationStart, long sourceStart, long length)> temperatureToHumidityRanges = new();
        List<(long destinationStart, long sourceStart, long length)> humidityToLocationRanges = new();

        string[] maps = input.Split("\n\n");

        foreach (var map in maps)
        {
            var mapName = map.Split(":").First();
            var mapRows = map.Split(":").Last().Trim().Split("\n").Select(row => row.Split(" ").Select(number => long.Parse(number)).ToArray());

            switch (mapName)
            {
                case "seeds":
                    seeds = mapRows.SelectMany(row => row).ToList();
                    break;
                case "seed-to-soil map":
                    seedToSoilRanges = mapRows.Select(row => (row[0], row[1], row[2])).ToList();
                    break;
                case "soil-to-fertilizer map":
                    soilToFertilizerRanges = mapRows.Select(row => (row[0], row[1], row[2])).ToList();
                    break;
                case "fertilizer-to-water map":
                    fertilizerToWaterRanges = mapRows.Select(row => (row[0], row[1], row[2])).ToList();
                    break;
                case "water-to-light map":
                    waterToLightRanges = mapRows.Select(row => (row[0], row[1], row[2])).ToList();
                    break;
                case "light-to-temperature map":
                    lightToTemperatureRanges = mapRows.Select(row => (row[0], row[1], row[2])).ToList();
                    break;
                case "temperature-to-humidity map":
                    temperatureToHumidityRanges = mapRows.Select(row => (row[0], row[1], row[2])).ToList();
                    break;
                case "humidity-to-location map":
                    humidityToLocationRanges = mapRows.Select(row => (row[0], row[1], row[2])).ToList();
                    break;
            }
        }

        var lowestLocation = long.MaxValue;

        foreach (var (humidityToLocationDestinationStart, humidityToLocationSourceStart, humidityToLocationLength) in humidityToLocationRanges)
        {
            var hasOverlap = false;

            foreach (var (temperatureToHumidityDestinationStart, temperatureToHumiditySourceStart, temperatureToHumidityLength) in temperatureToHumidityRanges)
            {
                var humidityToLocationSourceEnd = humidityToLocationSourceStart + humidityToLocationLength;
                var temperatureToHumidityEnd = temperatureToHumiditySourceStart + temperatureToHumidityLength;

                hasOverlap = humidityToLocationSourceStart <= temperatureToHumidityEnd && temperatureToHumiditySourceStart <= humidityToLocationSourceEnd;
                if (hasOverlap)
                {
                    Console.WriteLine("Overlap found!");
                    Console.WriteLine((humidityToLocationDestinationStart, humidityToLocationSourceStart, humidityToLocationLength));
                    Console.WriteLine((temperatureToHumidityDestinationStart, temperatureToHumiditySourceStart, temperatureToHumidityLength));
                }
            }
        }

        Console.WriteLine("Lowest location number");
        Console.WriteLine(lowestLocation);

        Console.WriteLine(result);
        Assert.Equal(-1, result);
    }

    [Fact]
    public void PartTwo()
    {
        long result = 0;

        Console.WriteLine(result);
        Assert.Equal(-1, result);
    }
}
