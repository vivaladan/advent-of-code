namespace AdventOfCode2025.Tests;

public class Day6Tests : TestBase
{
    [Fact]
    public void Day6_Part1_Sample()
    {
        Assert.Equal(4277556, Day6.Part1(
            "123 328  51 64 \n 45 64  387 23 \n  6 98  215 314\n*   +   *   +  "));
    }
    
    [Fact]
    public void Day6_Part1_Input()
    {
        Assert.Equal(6725216329103, Day6.Part1(
            LoadFromFile("Day6Input.txt")));
    }
    
    [Fact]
    public void Day6_Part2_Sample()
    {
        Assert.Equal(3263827, Day6.Part2(
            "123 328  51 64 \n 45 64  387 23 \n  6 98  215 314\n*   +   *   +  "));
    }
    
    [Fact]
    public void Day6_Part2_Input()
    {
        Assert.Equal(10600728112865, Day6.Part2(
            LoadFromFile("Day6Input.txt")));
    }
}