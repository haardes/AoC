using System.Text.RegularExpressions;

namespace _2015.Day11;

public class Day11
{
    private static readonly string[] input = File.ReadAllLines("../../../Day11/input.txt");
    public static readonly char[] illegalChars = new char[] { 'i', 'o', 'l' };
    public static readonly string pairRegex = "(.)\\1.*(.)\\2";
    public static readonly string consecutiveRegex = "(abc|bcd|cde|def|efg|fgh|ghi|hij|ijk|jkl|klm|lmn|mno|nop|opq|pqr|qrs|rst|stu|tuv|uvw|vwx|wxy|xyz)";

    [Fact]
    public void PartOne()
    {
        string result = "";

        Password password = new(input.First());
        int count = 0;

        while (!password.IsValid())
        {
            password.Increment();
            count++;
        }

        result = password.GetPassword();
        Console.WriteLine($"Incremented {count} times.");

        Console.WriteLine(result);
        Assert.Equal("hepxxyzz", result);
    }

    [Fact]
    public void PartTwo()
    {
        string result = "";

        Password password = new(input.First());
        int count = 0;
        bool foundFirst = false;

        while (!password.IsValid())
        {
            password.Increment();
            count++;

            if (!foundFirst)
            {
                foundFirst = password.IsValid();

                if (foundFirst)
                {
                    password.Increment();
                    count++;
                }
            }
        }

        result = password.GetPassword();
        Console.WriteLine($"Incremented {count} times.");

        Console.WriteLine(result);
        Assert.Equal("heqaabcc", result);
    }
}

public class Password
{
    private string _password;

    public Password(string password)
    {
        _password = password;
    }

    public void Increment()
    {
        string next = "";
        bool incrementDone = false;

        for (var i = _password.Length - 1; i >= 0; i--)
        {
            char c = _password[i];

            if (incrementDone)
            {
                next += c;
            }
            else
            {
                if (c != 'z')
                {
                    next += (char)(c + 1);
                    incrementDone = true;
                }
                else
                {
                    next += 'a';
                }
            }
        }

        _password = new string(next.Reverse().ToArray());
    }

    public bool IsValid()
    {
        if (_password.IndexOfAny(Day11.illegalChars) != -1) return false;
        if (!Regex.IsMatch(_password, Day11.pairRegex)) return false;
        if (!Regex.IsMatch(_password, Day11.consecutiveRegex)) return false;
        return true;
    }

    public string GetPassword()
    {
        return _password;
    }
}