namespace AdventOfCode2025.Tests;

public class Day1Tests : TestBase
{
    [Fact]
    public void Day1_Part1_Sample()
    {
        Assert.Equal("3", Day1.GetPwdFromSeq_Part1(["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"]));
    }

    [Fact]
    public void Day1_Part1_Input()
    {
        Assert.Equal("1195", Day1.GetPwdFromSeq_Part1(LoadLinesFromFile("Day1Input.txt")));
    }

    [Fact]
    public void Day1_Part2_Sample()
    {
        Assert.Equal("6", Day1.GetPwdFromSeq_Part2(["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"]));
    }

    [Fact]
    public void Day1_Part2_Input()
    {
        Assert.Equal("6770", Day1.GetPwdFromSeq_Part2(LoadLinesFromFile("Day1Input.txt")));
    }
}
