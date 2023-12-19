namespace _2015.Day09;

public class Day09
{
    private static readonly string[] input = File.ReadAllLines("../../../Day09/test_input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        Dictionary<string, NetworkNode> network = new();

        foreach (string line in input)
        {
            string[] distances = line.Split(" = ");
            int distance = int.Parse(distances.Last());
            string to = distances.First().Split(" to ").First();
            string from = distances.First().Split(" to ").Last();

            if (!network.TryGetValue(to, out NetworkNode? toNode))
            {
                toNode = new(to);
                network.Add(to, toNode);
            }

            if (!network.TryGetValue(from, out NetworkNode? fromNode))
            {
                fromNode = new(from);
                network.Add(from, fromNode);
            }

            network.GetValueOrDefault(to)!.AddNeighbour(network.GetValueOrDefault(from)!, distance);
            network.GetValueOrDefault(from)!.AddNeighbour(network.GetValueOrDefault(to)!, distance);
        }

        Console.WriteLine(result);
        Assert.Equal(-1, result);
    }

    public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> sequence)
    {
        if (sequence == null)
        {
            yield break;
        }

        var list = sequence.ToList();

        if (!list.Any())
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            var startingElementIndex = 0;

            foreach (var startingElement in list)
            {
                var index = startingElementIndex;
                var remainingItems = list.Where((e, i) => i != index);

                foreach (var permutationOfRemainder in Permute(remainingItems))
                {
                    yield return permutationOfRemainder.Prepend(startingElement);
                }

                startingElementIndex++;
            }
        }
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        Console.WriteLine(result);
        Assert.Equal(-1, result);
    }
}

public class NetworkNode
{
    public string Name;
    public List<(string Node, int Distance)> Neighbours = new();

    public NetworkNode(string name)
    {
        Name = name;
    }

    public NetworkNode AddNeighbour(NetworkNode node, int distance)
    {
        Neighbours.Add((node.Name, distance));
        return this;
    }
}
