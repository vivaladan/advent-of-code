namespace AdventOfCode2025.Tests;

public class Day2Tests : TestBase
{
    [Fact]
    public void Day2_Part1_Sample()
    {
        Assert.Equal(1227775554, Day2.CountInvalidIds_Part1(
            "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"));
    }
    
    [Fact]
    public void Day2_Part1_Input()
    {
        Assert.Equal(30608905813, Day2.CountInvalidIds_Part1(LoadFromFile("Day2Input.txt")));
    }
    
    [Fact]
    public void Day2_Part2_Sample()
    {
        Assert.Equal(4174379265, Day2.CountInvalidIds_Part2(
            "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"));
    }
    
    [Fact]
    public void Day2_Part2_Input()
    {
        Assert.Equal(31898925685, Day2.CountInvalidIds_Part2(LoadFromFile("Day2Input.txt")));
    }
}
