namespace _2015.Day16;

public class Day16
{
    private static readonly string[] input = File.ReadAllLines("../../../Day16/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        Dictionary<string, int> compounds = new() {
            {"children", 3},
            {"cats", 7},
            {"samoyeds", 2},
            {"pomeranians", 3},
            {"akitas", 0},
            {"vizslas", 0},
            {"goldfish", 5},
            {"trees", 3},
            {"cars", 2},
            {"perfumes", 1},
        };
        Dictionary<string, Dictionary<string, int>> sueCompounds = new();

        foreach (string line in input)
        {
            int firstColon = line.IndexOf(':');
            sueCompounds.Add(line[..firstColon], line[(firstColon + 1)..].Split(",").Select(t =>
            {
                string thing = t.Split(":").First().Trim();
                int count = int.Parse(t.Split(":").Last());
                return (thing, count);
            }).ToDictionary(t => t.thing, t => t.count));
        }

        foreach (var items in sueCompounds)
        {
            int sueNumber = int.Parse(items.Key.Split(" ").Last());
            bool hasMismatch = items.Value.Any(keyValuePair =>
            {
                if (!compounds.Contains(keyValuePair)) return true;
                return false;
            });

            if (!hasMismatch)
            {
                result = sueNumber;
                break;
            }
        }

        Console.WriteLine(result);
        Assert.Equal(373, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        Dictionary<string, int> compounds = new() {
            {"children", 3},
            {"cats", 7},
            {"samoyeds", 2},
            {"pomeranians", 3},
            {"akitas", 0},
            {"vizslas", 0},
            {"goldfish", 5},
            {"trees", 3},
            {"cars", 2},
            {"perfumes", 1},
        };
        Dictionary<string, Dictionary<string, int>> sueCompounds = new();

        foreach (string line in input)
        {
            int firstColon = line.IndexOf(':');
            sueCompounds.Add(line[..firstColon], line[(firstColon + 1)..].Split(",").Select(t =>
            {
                string thing = t.Split(":").First().Trim();
                int count = int.Parse(t.Split(":").Last());
                return (thing, count);
            }).ToDictionary(t => t.thing, t => t.count));
        }

        foreach (var items in sueCompounds)
        {
            int sueNumber = int.Parse(items.Key.Split(" ").Last());
            bool hasMismatch = items.Value.Any(kv =>
            {
                var key = kv.Key;
                var val = kv.Value;
                if (key == "cats" || key == "trees")
                {
                    return !(val > compounds.GetValueOrDefault(key));
                }
                else if (key == "pomeranians" || key == "goldfish")
                {
                    return !(val < compounds.GetValueOrDefault(key));
                }
                else if (!compounds.Contains(kv)) return true;
                return false;
            });

            if (!hasMismatch)
            {
                result = sueNumber;
                break;
            }
        }

        Console.WriteLine(result);
        Assert.Equal(260, result);
    }
}
