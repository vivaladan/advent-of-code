namespace AdventOfCode2025.Tests;

public class Day7Tests : TestBase
{
    private const string Sample =
        """
        .......S.......
        ...............
        .......^.......
        ...............
        ......^.^......
        ...............
        .....^.^.^.....
        ...............
        ....^.^...^....
        ...............
        ...^.^...^.^...
        ...............
        ..^...^.....^..
        ...............
        .^.^.^.^.^...^.
        ...............
        """;
    
    [Fact]
    public void Day7_Part1_Sample()
    {
        Assert.Equal(21, Day7.Part1(Sample));
    }

    [Fact]
    public void Day7_Part1_Input()
    {
        Assert.Equal(1642, Day7.Part1(LoadFromFile("Day7Input.txt")));
    }

    [Fact]
    public void Day7_Part2_Sample()
    {
        Assert.Equal(40, Day7.Part2(Sample));
    }

    [Fact]
    public void Day7_Part2_Input()
    {
        Assert.Equal(47274292756692, Day7.Part2(LoadFromFile("Day7Input.txt")));
    }
}