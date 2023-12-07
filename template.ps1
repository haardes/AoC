$Year = Read-Host -Prompt "For what year do you wish to create the structure?"

for ($Day = 2; $Day -le 24; $Day++) {
    $Content = @"
namespace _2023.Day$Day;

public class Day1 
{
    private static readonly string[] input = File.ReadAllLines("../../../Day$Day/input.txt");

    [Fact]
    public void PartOne()
    {
        int result = 0;

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
"@

    New-Item -ItemType Directory -Path "./$Year/Day$Day"

    New-Item -ItemType File -Path "./$Year/Day$Day/Day$Day.cs"
    New-Item -ItemType File -Path "./$Year/Day$Day/input.txt"
    New-Item -ItemType File -Path "./$Year/Day$Day/test_input.txt"

    $Content | Out-File -Append "./$Year/Day $Day/Day$Day.cs"
}