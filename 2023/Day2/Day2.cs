
namespace _2023.Day2;

public class Day2
{
    private static readonly string[] input = File.ReadAllLines("../../../Day2/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        int maxRed = 12;
        int maxGreen = 13;
        int maxBlue = 14;

        foreach (string line in input)
        {
            int gameId = int.Parse(line.Split(":").First().Split(" ").Last());
            string gameString = line.Split(":").Last();
            bool validGame = true;

            string[] sets = gameString.Split(";");

            foreach (string set in sets)
            {
                if (!validGame)
                {
                    break;
                }

                string[] cubeStrings = set.Split(",");
                foreach (string cubeString in cubeStrings)
                {
                    int count = int.Parse(cubeString.Trim().Split(" ").First());
                    string color = cubeString.Trim().Split(" ").Last();

                    if (color == "red")
                    {
                        if (count > maxRed)
                        {
                            validGame = false;
                            break;
                        }
                    }

                    if (color == "green")
                    {
                        if (count > maxGreen)
                        {
                            validGame = false;
                            continue;
                        }
                    }

                    if (color == "blue")
                    {
                        if (count > maxBlue)
                        {
                            validGame = false;
                            continue;
                        }
                    }
                }
            }

            if (!validGame) continue;

            result += gameId;
        }

        Console.WriteLine(result);
        Assert.Equal(3059, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        foreach (string line in input)
        {
            string gameString = line.Split(":").Last();

            result += CalculatePowerForGame(gameString);
        }

        Console.WriteLine(result);
        Assert.Equal(65371, result);
    }

    private static int CalculatePowerForGame(string gameString)
    {
        string[] sets = gameString.Split(";");
        int maxRed = 0;
        int maxGreen = 0;
        int maxBlue = 0;

        foreach (string set in sets)
        {
            string[] cubeStrings = set.Split(",");
            foreach (string cubeString in cubeStrings)
            {
                int count = int.Parse(cubeString.Trim().Split(" ").First());
                string color = cubeString.Trim().Split(" ").Last();

                if (color == "red" && count > maxRed)
                {
                    maxRed = count;
                }

                if (color == "green" && count > maxGreen)
                {
                    maxGreen = count;
                }

                if (color == "blue" && count > maxBlue)
                {
                    maxBlue = count;
                }
            }
        }

        return maxRed * maxGreen * maxBlue;
    }
}
