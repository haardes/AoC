namespace _2015.Day06;

public class Day06
{
    private static readonly string[] input = File.ReadAllLines("../../../Day06/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;
        int[] lights = new int[1000000];

        foreach (string line in input)
        {
            var instructions = line.Split(" ").Reverse();

            int[] endPositions = instructions.First().Split(",").Select(num => int.Parse(num)).ToArray();
            (int X, int Y) end = (endPositions[0], endPositions[1]);

            int[] startPositions = instructions.ElementAt(2).Split(",").Select(num => int.Parse(num)).ToArray();
            (int X, int Y) start = (startPositions[0], startPositions[1]);

            string instruction = instructions.ElementAt(3);

            for (var x = start.X; x <= end.X; x++)
            {
                for (var y = start.Y; y <= end.Y; y++)
                {
                    int index = y * 1000 + x;

                    switch (instruction)
                    {
                        case "on":
                            lights[index] = 1;
                            break;
                        case "off":
                            lights[index] = 0;
                            break;
                        case "toggle":
                            lights[index] = lights[index] == 1 ? 0 : 1;
                            break;
                    }
                }
            }
        }

        result = lights.Count(light => light == 1);

        Console.WriteLine(result);
        Assert.Equal(377891, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;
        int[] lights = new int[1000000];

        foreach (string line in input)
        {
            var instructions = line.Split(" ").Reverse();

            int[] endPositions = instructions.First().Split(",").Select(num => int.Parse(num)).ToArray();
            (int X, int Y) end = (endPositions[0], endPositions[1]);

            int[] startPositions = instructions.ElementAt(2).Split(",").Select(num => int.Parse(num)).ToArray();
            (int X, int Y) start = (startPositions[0], startPositions[1]);

            string instruction = instructions.ElementAt(3);

            for (var x = start.X; x <= end.X; x++)
            {
                for (var y = start.Y; y <= end.Y; y++)
                {
                    int index = y * 1000 + x;

                    switch (instruction)
                    {
                        case "on":
                            lights[index] += 1;
                            break;
                        case "off":
                            if (lights[index] == 0)
                            {
                                break;
                            }

                            lights[index] -= 1;
                            break;
                        case "toggle":
                            lights[index] += 2;
                            break;
                    }
                }
            }
        }

        result = lights.Aggregate((light, sum) => sum + light);

        Console.WriteLine(result);
        Assert.Equal(14110788, result);
    }
}
