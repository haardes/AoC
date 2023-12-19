namespace _2015.Day09;

public class Day09
{
    private static readonly string[] input = File.ReadAllLines("../../../Day09/test_input.txt");
    private readonly List<NetworkNode> networkNodes = new();

    [Fact]
    public void PartOne()
    {
        int result = int.MaxValue;
        CreateNetworkFromInput();
        DisplayNetwork();

        List<List<NetworkNode>> permutations = GeneratePermutations();

        foreach (var permutation in permutations)
        {
            int cost = 0;
            NetworkNode previous = permutation.First();

            foreach (var node in permutation)
            {
                cost += GetDistance(previous, node);
                previous = node;
            }

            if (cost < result) result = cost;
        }

        Console.WriteLine(result);
        Assert.Equal(-1, result);
    }

    private List<List<NetworkNode>> GeneratePermutations()
    {
        throw new NotImplementedException();
    }

    private static int GetDistance(NetworkNode previous, NetworkNode node)
    {
        return previous.Neighbours.Find(n => n.Node.Name == node.Name).Distance;
    }

    private void CreateNetworkFromInput()
    {
        foreach (string line in input)
        {
            string[] distances = line.Split(" = ");
            int distance = int.Parse(distances.Last());
            string to = distances.First().Split(" to ").First();
            string from = distances.First().Split(" to ").Last();

            NetworkNode? toNode = networkNodes.Find(node => node.Name == to);
            NetworkNode? fromNode = networkNodes.Find(node => node.Name == from);

            if (toNode == null)
            {
                toNode = new(to);
                networkNodes.Add(toNode);
            }

            if (fromNode == null)
            {
                fromNode = new(from);
                networkNodes.Add(fromNode);
            }

            toNode.AddNeighbour(fromNode, distance);
            fromNode.AddNeighbour(toNode, distance);
        }
    }

    private void DisplayNetwork()
    {
        foreach (NetworkNode node in networkNodes)
        {
            Console.Write($"{node.Name,-10}: ");
            node.Neighbours.ForEach(neighbour => Console.Write($"({neighbour.Node.Name,-10}, {neighbour.Distance:d3}), "));
            Console.WriteLine();
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
    public List<(NetworkNode Node, int Distance)> Neighbours = new();

    public NetworkNode(string name)
    {
        Name = name;
    }

    public NetworkNode AddNeighbour(NetworkNode node, int distance)
    {
        Neighbours.Add((node, distance));
        return this;
    }
}
