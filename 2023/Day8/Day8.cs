namespace _2023.Day08;

public class Day08
{
    private static readonly string[] input = File.ReadAllText("../../../Day8/input.txt").Split("\n\n");
    public Dictionary<string, LRNode> NodeDictionary = new();

    [Fact]
    public void PartOne()
    {
        int result = 0;

        (string directions, string[] nodes) = (input[0], input[1].Split("\n"));
        FillNodeDictionary(nodes);

        LRNode current = NodeDictionary.GetValueOrDefault("AAA")!;
        int counter = 0;

        while (current!.Value != "ZZZ")
        {
            char direction = directions[counter];

            if (direction == 'L')
            {
                current = current.Left!;
            }
            else
            {
                current = current.Right!;
            }

            result++;
            counter++;

            if (counter == directions.Length)
            {
                counter = 0;
            }
        }

        Console.WriteLine(result);
        Assert.Equal(11911, result);
    }

    [Fact]
    public void PartTwo()
    {
        (string directions, string[] nodes) = (input[0], input[1].Split("\n"));
        FillNodeDictionary(nodes);

        var currentNodes = NodeDictionary.Where(node => node.Key.EndsWith("A")).Select(node => node.Value);
        long[] results = new long[currentNodes.Count()];

        int currentIndex = 0;
        foreach (var node in currentNodes)
        {
            int counter = 0;
            long currentResult = 0;
            LRNode current = node;

            while (!current.Value.EndsWith("Z"))
            {
                char direction = directions[counter];

                if (direction == 'L')
                {
                    current = current.Left!;
                }
                else
                {
                    current = current.Right!;
                }

                currentResult++;
                counter++;

                if (counter == directions.Length)
                {
                    counter = 0;
                }
            }

            Console.WriteLine($"Completed searching node {node.Value} after {currentResult} directions");
            results[currentIndex] = currentResult;
            currentIndex++;
        }

        /* Tar ALT for lang tid å kjøre (typ 100 år)
        while (!currentNodes.All(node => node.Value.EndsWith("Z")))
        {
            char direction = directions[counter];

            if (direction == 'L')
            {
                currentNodes = currentNodes.Select(node => node.Left!);
            }
            else
            {
                currentNodes = currentNodes.Select(node => node.Right!);
            }

            result++;
            counter++;

            if (counter == directions.Length)
            {
                counter = 0;
            }
        } */

        var result = results[0];

        foreach (var c in results[1..results.Length])
        {
            var currentSteps = result;

            while (result % c != 0) result += currentSteps;
        }

        Console.WriteLine(result);
        Assert.Equal(10151663816849, result);
    }

    private void FillNodeDictionary(string[] nodes)
    {
        foreach (var line in nodes)
        {
            string[] nodeParts = line.Split(" = ");
            string node = nodeParts[0];
            string[] neighbours = nodeParts[1].Trim('(', ')').Split(", ");

            LRNode current = NodeDictionary.GetValueOrDefault(node, new(node));
            NodeDictionary.TryAdd(node, current);

            if (!NodeDictionary.TryGetValue(neighbours[0], out LRNode? left))
            {
                left = new(neighbours[0]);
                NodeDictionary.Add(neighbours[0], left);
            }

            if (!NodeDictionary.TryGetValue(neighbours[1], out LRNode? right))
            {
                right = new(neighbours[1]);
                NodeDictionary.Add(neighbours[1], right);
            }

            current.Left = left;
            current.Right = right;
        }
    }

    static int GCM(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static int LCM(int a, int b)
    {
        return a / GCM(a, b) * b;
    }
}

public class LRNode
{
    public string Value;
    public LRNode? Left;
    public LRNode? Right;

    public LRNode(string value)
    {
        Value = value;
    }
}