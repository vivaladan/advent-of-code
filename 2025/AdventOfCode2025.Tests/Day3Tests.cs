namespace AdventOfCode2025.Tests;

public class Day3Tests : TestBase
{
    [Fact]
    public void Day3_Part1_Sample()
    {
        Assert.Equal(357, Day3.FindMaximumJoltage_Part1(
            "987654321111111\n811111111111119\n234234234234278\n818181911112111"));
    }
    
    [Fact]
    public void Day3_Part1_Input()
    {
        Assert.Equal(17263, Day3.FindMaximumJoltage_Part1(
            LoadFromFile("Day3Input.txt")));
    }
    
    [Fact]
    public void Day3_Part2_Sample()
    {
        Assert.Equal(3121910778619, Day3.FindMaximumJoltage_Part2(
            "987654321111111\n811111111111119\n234234234234278\n818181911112111"));
    }
    
    [Fact]
    public void Day3_Part2_Input()
    {
        Assert.Equal(170731717900423, Day3.FindMaximumJoltage_Part2(
            LoadFromFile("Day3Input.txt")));
    }
}