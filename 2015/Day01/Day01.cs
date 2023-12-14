namespace _2015.Day01;

public class Day01
{
    private static readonly string input = File.ReadAllText("../../../Day01/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        foreach (char c in input)
        {
            if (c == '(')
            {
                result++;
            }
            else
            {
                result--;
            }
        }

        Console.WriteLine(result);
        Assert.Equal(232, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;
        int count = 1;

        foreach (char c in input)
        {
            if (c == '(')
            {
                result++;
            }
            else
            {
                result--;
            }

            if (result == -1)
            {
                result = count;
                break;
            }

            count++;
        }

        Console.WriteLine(result);
        Assert.Equal(1783, result);
    }
}
