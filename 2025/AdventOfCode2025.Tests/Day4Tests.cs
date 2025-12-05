namespace AdventOfCode2025.Tests;

public class Day4Tests : TestBase
{
    [Fact]
    public void Day4_Part1_Sample()
    {
        Assert.Equal(13, Day4.FindMovableRolls_Part1(
            "..@@.@@@@.\n@@@.@.@.@@\n@@@@@.@.@@\n@.@@@@..@.\n@@.@@@@.@@\n.@@@@@@@.@\n.@.@.@.@@@\n@.@@@.@@@@\n.@@@@@@@@.\n@.@.@@@.@."));
    }
    
    [Fact]
    public void Day4_Part1_Input()
    {
        Assert.Equal(1543, Day4.FindMovableRolls_Part1(
            LoadFromFile("Day4Input.txt")));
    }
    
    [Fact]
    public void Day4_Part2_Sample()
    {
        Assert.Equal(43, Day4.FindMovableRolls_Part2(
            "..@@.@@@@.\n@@@.@.@.@@\n@@@@@.@.@@\n@.@@@@..@.\n@@.@@@@.@@\n.@@@@@@@.@\n.@.@.@.@@@\n@.@@@.@@@@\n.@@@@@@@@.\n@.@.@@@.@."));
    }
    
    [Fact]
    public void Day4_Part2_Input()
    {
        Assert.Equal(9038, Day4.FindMovableRolls_Part2(
            LoadFromFile("Day4Input.txt")));
    }   
}