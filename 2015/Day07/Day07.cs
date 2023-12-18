using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Helpers;

namespace _2015.Day07;

public class Day07
{
    private static readonly string[] input = File.ReadAllLines("../../../Day07/input.txt");
    private Dictionary<string, string> commands = new();
    private Dictionary<string, ushort> wires = new();

    [Fact]
    public void PartOne()
    {
        int result = 0;

        foreach (string line in input)
        {
            string command = line.Split(" -> ").First();
            string targetWire = line.Split(" -> ").Last();

            commands.Add(targetWire, command);
        }

        result = GetWireValue("a");

        Console.WriteLine(result);
        Assert.Equal(16076, result);
    }

    private ushort GetWireValue(string wireKey)
    {
        if (ushort.TryParse(wireKey, out ushort value)) return value;
        if (!commands.TryGetValue(wireKey, out string? command)) throw new Exception($"Something went wrong fetching key {wireKey}");
        if (wires.TryGetValue(wireKey, out ushort cachedValue)) return cachedValue;

        ushort result = 0;
        string[] instructions = command.Split(" ");

        switch (instructions.Length)
        {
            case 1:
                string valueOrWire = instructions.First();
                if (ushort.TryParse(valueOrWire, out ushort wireValue))
                {
                    result = wireValue;
                }
                else
                {
                    result = GetWireValue(valueOrWire);
                }
                break;
            case 2:
                string wire = instructions.Last();
                result = (ushort)~GetWireValue(wire);
                break;
            case 3:
                string wireOrValue = instructions[0];
                string instruction = instructions[1];
                string wireOrValue2 = instructions[2];

                switch (instruction)
                {
                    case "AND":
                        result = (ushort)(GetWireValue(wireOrValue) & GetWireValue(wireOrValue2));
                        break;
                    case "OR":
                        result = (ushort)(GetWireValue(wireOrValue) ^ GetWireValue(wireOrValue2));
                        break;
                    case "LSHIFT":
                        result = (ushort)(GetWireValue(wireOrValue) << GetWireValue(wireOrValue2));
                        break;
                    case "RSHIFT":
                        result = (ushort)(GetWireValue(wireOrValue) >> GetWireValue(wireOrValue2));
                        break;
                }
                break;
        }

        wires.Add(wireKey, result);
        return result;
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        /* Now, take the signal you got on wire a, override wire b to that signal, and reset the other wires (including wire a). What new signal is ultimately provided to wire a? */
        foreach (string line in input)
        {
            string command = line.Split(" -> ").First();
            string targetWire = line.Split(" -> ").Last();

            commands.Add(targetWire, command);
        }

        result = GetWireValue("a");
        wires = new()
        {
            { "b", (ushort)result }
        };
        result = GetWireValue("a");

        Console.WriteLine(result);
        Assert.Equal(2797, result);
    }
}
