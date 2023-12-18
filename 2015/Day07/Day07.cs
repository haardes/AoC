namespace _2015.Day07;

public class Day07
{
    private static readonly string[] input = File.ReadAllLines("../../../Day07/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;
        Dictionary<string, ushort> wires = new();

        foreach (string line in input)
        {
            string[] parts = line.Split(" -> ");

            string wireKey = parts.Last();

            if (!wires.ContainsKey(wireKey))
            {
                wires.Add(wireKey, 0);
            }

            string[] instructions = parts.First().Split(" ");
            Console.WriteLine(line);

            if (instructions.Length == 1)
            {
                try
                {
                    wires[wireKey] = ushort.Parse(instructions.First());
                }
                catch (FormatException)
                {
                    wires[wireKey] = wires.GetValueOrDefault(instructions.First());
                }
            }
            else if (instructions.Length == 2)
            {
                wires[wireKey] = (ushort)~wires.GetValueOrDefault(instructions.Last());
            }
            else
            {
                string firstWireKey = instructions.First();
                string instruction = instructions.ElementAt(1);
                string lastKey = instructions.Last();

                switch (instruction)
                {
                    case "AND":
                        wires[wireKey] = (ushort)(wires.GetValueOrDefault(firstWireKey) & wires.GetValueOrDefault(lastKey));
                        break;
                    case "OR":
                        wires[wireKey] = (ushort)(wires.GetValueOrDefault(firstWireKey) ^ wires.GetValueOrDefault(lastKey));
                        break;
                    case "LSHIFT":
                        wires[wireKey] = (ushort)(wires.GetValueOrDefault(firstWireKey) << int.Parse(lastKey));
                        break;
                    case "RSHIFT":
                        wires[wireKey] = (ushort)(wires.GetValueOrDefault(firstWireKey) >> int.Parse(lastKey));
                        break;
                }
            }
        }

        foreach (var wire in wires)
        {
            Console.WriteLine(wire);
        }

        result = wires["a"];

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
