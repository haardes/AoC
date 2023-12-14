Param(
    [Parameter(Mandatory=$True)]
    [int]$year,
    [switch]$next
)

if ($next) {
    $FolderPath = "./$year";

    if (!(Test-Path -Path $FolderPath)) {
        New-Item -ItemType Directory -Path "./$year"
    }

    $LatestDayFile = (Get-ChildItem -Path $FolderPath | Where-Object {$_.name -match 'Day'} | Sort-Object { [regex]::Replace($_.Name, '\d+', { $args[0].Value.PadLeft(20) }) } | select -Last 1).Name;
    $LatestDay = [int]$LatestDayFile.Substring($LatestDayFile.Length - 2);
    $DayString = '{0:d2}' -f ($LatestDay + 1)
    $Content = @"
namespace _2023.Day$DayString;

public class Day$DayString 
{
    private static readonly string[] input = File.ReadAllLines("../../../Day$DayString/input.txt");

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

    New-Item -ItemType Directory -Path "./$Year/Day$DayString"

    New-Item -ItemType File -Path "./$Year/Day$DayString/Day$DayString.cs"
    New-Item -ItemType File -Path "./$Year/Day$DayString/input.txt"
    New-Item -ItemType File -Path "./$Year/Day$DayString/test_input.txt"

    $Content | Out-File -Append "./$Year/Day$DayString/Day$DayString.cs"
}