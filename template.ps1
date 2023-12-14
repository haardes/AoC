Param(
    [Parameter(Mandatory=$True)]
    [int]$year,
    [switch]$next
)

if ($next) {
    if (!(Test-Path -Path "./$year")) {
        & dotnet new xunit -n $year
        & dotnet add reference "./$year/$year.csproj"

        Remove-Item -Path "./$year/UnitTest1.cs"

        "`nglobal using System;" | Out-File -Append "./$year/Usings.cs"
    }

    $LatestDayFile = (Get-ChildItem -Path "./$year" | Where-Object {$_.name -match 'Day'} | Sort-Object { [regex]::Replace($_.Name, '\d+', { $args[0].Value.PadLeft(20) }) } | select -Last 1).Name

    if (!$LatestDayFile) {
        $LatestDay = 0
    } else {
        $LatestDay = [int]$LatestDayFile.Substring($LatestDayFile.Length - 2)
    }

    $DayString = '{0:d2}' -f ($LatestDay + 1)
    $Content = @"
namespace _$year.Day$DayString;

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

    New-Item -ItemType Directory -Path "./$year/Day$DayString"

    New-Item -ItemType File -Path "./$year/Day$DayString/Day$DayString.cs"
    New-Item -ItemType File -Path "./$year/Day$DayString/input.txt"
    New-Item -ItemType File -Path "./$year/Day$DayString/test_input.txt"

    $Content | Out-File -Append "./$year/Day$DayString/Day$DayString.cs"
}