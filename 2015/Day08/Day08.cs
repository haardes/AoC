using System.Text.RegularExpressions;

namespace _2015.Day08;

public class Day08 
{
    private static readonly string[] input = File.ReadAllLines("../../../Day08/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

        int stringCharacters = 0;
        int memoryCharacters = 0;

        foreach(var line in input) {
            stringCharacters += line.Length;
            memoryCharacters += Regex.Unescape(line[1..(line.Length - 1)]).Length;
        }

        result = stringCharacters - memoryCharacters;

        Console.WriteLine(result);
        Assert.Equal(1342, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        int stringCharacters = 0;
        int escapedCharacters = 0;

        foreach(var line in input) {
            string escaped = "\"\"";
            
            foreach (char c in line)
            {
                if (c == '"') {
                    escaped += "\\\"";
                } else if (c == '\\') {
                    escaped += "\\\\";
                } else {
                    escaped += c;
                }
            }

            stringCharacters += line.Length;
            escapedCharacters += escaped.Length;

            Console.WriteLine($"Line: {line} ({line.Length})");
            Console.WriteLine($"Escp: {escaped} ({escaped.Length})");
        }

        result = escapedCharacters - stringCharacters;

        Console.WriteLine(result);
        Assert.Equal(-1, result);
    }
}
