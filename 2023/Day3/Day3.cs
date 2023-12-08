namespace _2023.Day03;

public class Day03
{
    private static readonly string[] input = File.ReadAllLines("../../../Day3/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        for (var x = 0; x < input.Length; x++)
        {
            for (var y = 0; y < input[x].Length; y++)
            {
                char cell = input[x][y];

                if (!char.IsDigit(cell))
                {
                    continue;
                }

                bool isValidPartNumber = false;
                string number = "";

                // Left
                if (y > 0)
                {
                    isValidPartNumber = !input[x][y - 1].Equals('.');
                }

                // Left above
                if (y > 0 && x > 0)
                {
                    isValidPartNumber = !input[x - 1][y - 1].Equals('.');
                }

                // Left below
                if (y > 0 && x < input.Length - 1)
                {
                    isValidPartNumber = !input[x + 1][y - 1].Equals('.');
                }

                // Above
                if (x > 0)
                {
                    isValidPartNumber = !input[x - 1][y].Equals('.');
                }

                // Below
                if (x < input.Length - 1)
                {
                    isValidPartNumber = !input[x + 1][y].Equals('.');
                }

                while (y < input[x].Length - 1 && char.IsDigit(input[x][y]))
                {
                    number += input[x][y];

                    // Right above
                    if (x > 0 && y < input[x].Length - 1)
                    {
                        isValidPartNumber = !input[x - 1][y + 1].Equals('.');
                    }

                    // Right below
                    if (x < input.Length - 1 && y < input[x].Length - 1)
                    {
                        isValidPartNumber = !input[x + 1][y + 1].Equals('.');
                    }

                    y++;
                }

                // Right
                if (y < input[x].Length - 1)
                {
                    isValidPartNumber = !input[x][y + 1].Equals('.');
                }

                if (isValidPartNumber)
                {
                    result += int.Parse(number);
                }
            }
        }

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
