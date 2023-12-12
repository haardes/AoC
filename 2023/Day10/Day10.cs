namespace _2023.Day10;

public class Day10
{
    private static readonly string[] input = File.ReadAllLines("../../../Day10/input.txt");
    public HashSet<string> Seen = new();

    [Fact]
    public void PartOne()
    {
        int result = 0;
        char[][] grid = input.Select(row => row.ToCharArray()).ToArray();
        bool foundLoop = false;

        (int X, int Y) start = FindStartingPosition(grid);
        (int X, int Y) position = start;

        while (!foundLoop)
        {
            Seen.Add($"{position.X},{position.Y}");
            position = NextConnectingPipe(grid, position);
        }

        //while (!(X == StartX && Y == StartY) && loopLength < input.Length * input.Last().Length)

        File.WriteAllText("../../../Day10/grid.txt", string.Join('\n', grid.Select(row => new string(row))));

        Console.WriteLine(result);
        Assert.Equal(-1, result);
    }

    private (int X, int Y) NextConnectingPipe(char[][] grid, (int X, int Y) position)
    {
        (int X, int Y) up = (position.X - 1, position.Y);
        (int X, int Y) right = (position.X, position.Y + 1);
        (int X, int Y) down = (position.X + 1, position.Y);
        (int X, int Y) left = (position.X, position.Y - 1);

        var validUps = new List<char>();
        var validRights = new List<char>();
        var validDowns = new List<char>();
        var validLefts = new List<char>();

        switch (grid[position.X][position.Y])
        {
            case 'S':
                validUps = new() { '|', '7', 'F' };
                validRights = new() { '-', '7', 'J' };
                validDowns = new() { '|', 'L', 'J' };
                validLefts = new() { '-', 'L', 'F' };
                break;
            case '|':
                validUps = new() { '|', '7', 'F' };
                validDowns = new() { '|', 'L', 'J' };
                break;
            case '-':
                validRights = new() { '-', '7', 'J' };
                validLefts = new() { '-', 'L', 'F' };
                break;
            case '7':
                validDowns = new() { '|', 'L', 'J' };
                validLefts = new() { '-', 'L', 'F' };
                break;
            case 'F':
                validRights = new() { '-', '7', 'J' };
                validDowns = new() { '|', 'L', 'J' };
                break;
            case 'J':
                validUps = new() { '|', '7', 'F' };
                validLefts = new() { '-', 'L', 'F' };
                break;
            case 'L':
                validUps = new() { '|', '7', 'F' };
                validRights = new() { '-', '7', 'J' };
                break;
        }

        if (validUps.Contains(grid[up.X][up.Y]))
        {
            if (!Seen.Contains($"{up.X},{up.Y}"))
            {
                return up;
            }
        }

        if (validRights.Contains(grid[right.X][right.Y]))
        {
            if (!Seen.Contains($"{right.X},{right.Y}"))
            {
                return right;
            }
        }

        if (validDowns.Contains(grid[down.X][down.Y]))
        {
            if (!Seen.Contains($"{down.X},{down.Y}"))
            {
                return down;
            }
        }

        if (validLefts.Contains(grid[left.X][left.Y]))
        {
            if (!Seen.Contains($"{left.X},{left.Y}"))
            {
                return left;
            }
        }

        throw new Exception($"No valid pipe found for {position} with char {grid[position.X][position.Y]}.");
    }

    private static (int X, int Y) FindStartingPosition(char[][] grid)
    {
        for (var x = 0; x < grid.Length; x++)
        {
            for (var y = 0; y < grid[x].Length; y++)
            {
                char c = grid[x][y];

                if (c == 'S')
                {
                    //grid[x][y] = '■';
                    return (x, y);
                }
            }
        }

        throw new Exception("No starting position found!!!");
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        Console.WriteLine(result);
        Assert.Equal(-1, result);
    }
}
