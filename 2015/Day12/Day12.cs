using System.Text.RegularExpressions;

namespace _2015.Day12;

public class Day12
{
    private static readonly string json = File.ReadAllText("../../../Day12/input.txt");
    private static readonly string digitRegex = "-*\\d+";
    private static readonly string redRegex = "\"red\"";

    [Fact]
    public void PartOne()
    {
        int result = 0;

        MatchCollection matches = Regex.Matches(json, digitRegex);
        result = matches.Select(match => int.Parse(match.Value)).Aggregate((value, sum) => sum + value);

        Console.WriteLine(result);
        Assert.Equal(191164, result);
    }

    [Fact]
    public void PartTwo()
    {
        int result = 0;

        string greenJson = json;

        while (Regex.IsMatch(greenJson, redRegex))
        {
            var match = Regex.Match(greenJson, redRegex);
            var matchIndex = match.Index;
            int specialCount = 0;

            for (var i = matchIndex; i >= 0; i--)
            {
                char c = greenJson[i];

                if (specialCount == 0)
                {
                    if (c == '[')
                    {
                        greenJson = greenJson.Remove(matchIndex, match.Length).Insert(matchIndex, "\"r\"");
                        break;
                    }

                    if (c == '{')
                    {
                        int closingBracketIndex = -1;
                        int jSpecialcount = 0;
                        for (var j = matchIndex + match.Length; j < greenJson.Length; j++)
                        {
                            char jC = greenJson[j];
                            if (jC == '}' && jSpecialcount == 0)
                            {
                                closingBracketIndex = j;
                                break;
                            }
                            else if (jC == '{') jSpecialcount++;
                            else if (jC == '}') jSpecialcount--;
                        }

                        greenJson = greenJson.Remove(i, closingBracketIndex - i + 1);
                        break;
                    }

                    if (c == ']' || c == '}')
                    {
                        specialCount++;
                    }
                }
                else
                {
                    if (c == '{' || c == '[')
                    {
                        specialCount--;
                    }
                    else if (c == '}' || c == ']')
                    {
                        specialCount++;
                    }
                }
            }
        }

        MatchCollection matches = Regex.Matches(greenJson, digitRegex);
        result = matches.Select(match => int.Parse(match.Value)).Aggregate((value, sum) => sum + value);

        Console.WriteLine(result);
        Assert.Equal(87842, result);
    }
}
