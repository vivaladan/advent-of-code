namespace AdventOfCode2025.Tests;

public class Day5Tests : TestBase
{
    [Fact]
    public void Day5_Part1_Sample()
    {
        Assert.Equal(3, Day5.FindFreshIngredients_Part1(
            "3-5\n10-14\n16-20\n12-18\n\n1\n5\n8\n11\n17\n32"));
    }
    
    [Fact]
    public void Day5_Part1_Input()
    {
        Assert.Equal(615, Day5.FindFreshIngredients_Part1(
            LoadFromFile("Day5Input.txt")));
    }
    
    [Fact]
    public void Day5_Part2_Sample()
    {
        Assert.Equal(14, Day5.FindFreshIngredients_Part2(
            "3-5\n10-14\n16-20\n12-18\n\n1\n5\n8\n11\n17\n32"));
    }
    
    [Fact]
    public void Day5_Part2_Input()
    {
        Assert.Equal(353716783056994, Day5.FindFreshIngredients_Part2(
            LoadFromFile("Day5Input.txt")));
    }
}