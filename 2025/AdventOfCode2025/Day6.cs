namespace AdventOfCode2025;

public class Day6
{
    public static long Part1(string input)
    {
        var grid = input
            .Split(Environment.NewLine)
            .Select(c => c.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToArray();

        var yMax = grid.Length;
        var xMax = grid[0].Length;

        var total = 0L;
        for (var x = 0; x < xMax; x++)
        {
            var op = grid[yMax - 1][x];
            total += Enumerable.Range(0, yMax - 1)
                .Select(y => long.Parse(grid[y][x]))
                .Aggregate((a, b) => op switch { "+" => a + b, "*" => a * b });
        }

        return total;
    }

    public static long Part2(string input)
    {
        var grid = input.Split(Environment.NewLine);

        var yMax = grid.Length;
        var xMax = grid[0].Length;

        var tot = 0L;
        var cur = 0L;
        var op = ' ';

        for (var x = 0; x < xMax; x++)
        {
            if (grid[yMax - 1][x] is var newOp and not ' ')
            {
                op = newOp;
                cur = op == '*' ?  1 : 0;
            }

            var val = string.Concat(
                Enumerable.Range(0, yMax - 1)
                    .Select(y => grid[y][x])
                    .Where(c => c is not ' '));

            if (val != string.Empty)
            {
                cur = op switch
                {
                    '+' => cur + int.Parse(val),
                    '*' => cur * int.Parse(val),
                };
            }
            else
            {
                tot += cur;
            }
        }
        tot += cur;
        

        return tot;
    }
}