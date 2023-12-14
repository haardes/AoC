namespace _2015.Day03;

public class Day03
{
    private static readonly string input = File.ReadAllText("../../../Day03/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        HashSet<(int, int)> visited = new();
        (int x, int y) = (0, 0);
        visited.Add((x, y));

        foreach (char c in input)
        {
            switch (c)
            {
                case 'v':
                    y += 1;
                    break;
                case '>':
                    x += 1;
                    break;
                case '^':
                    y -= 1;
                    break;
                case '<':
                    x -= 1;
                    break;
            }

            visited.Add((x, y));
        }

        result = visited.Count;

        Console.WriteLine(result);
        Assert.Equal(2572, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        HashSet<(int, int)> visitedBySanta = new();
        HashSet<(int, int)> visitedByRoboSanta = new();
        (int X, int Y) santa = (0, 0);
        (int X, int Y) roboSanta = (0, 0);
        visitedBySanta.Add((santa.X, santa.Y));
        visitedByRoboSanta.Add((roboSanta.X, roboSanta.Y));

        bool santasTurn = true;

        foreach (char c in input)
        {
            switch (c)
            {
                case 'v':
                    if (santasTurn)
                    {
                        santa.Y += 1;
                    }
                    else
                    {
                        roboSanta.Y += 1;
                    }
                    break;
                case '>':
                    if (santasTurn)
                    {
                        santa.X += 1;
                    }
                    else
                    {
                        roboSanta.X += 1;
                    }
                    break;
                case '^':
                    if (santasTurn)
                    {
                        santa.Y -= 1;
                    }
                    else
                    {
                        roboSanta.Y -= 1;
                    }
                    break;
                case '<':
                    if (santasTurn)
                    {
                        santa.X -= 1;
                    }
                    else
                    {
                        roboSanta.X -= 1;
                    }
                    break;
            }

            if (santasTurn)
            {
                visitedBySanta.Add((santa.X, santa.Y));
            }
            else
            {
                visitedByRoboSanta.Add((roboSanta.X, roboSanta.Y));
            }

            santasTurn = !santasTurn;
        }

        result = visitedByRoboSanta.Union(visitedBySanta).Count();

        Console.WriteLine(result);
        Assert.Equal(2631, result);
    }
}
