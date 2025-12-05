using System.Runtime.InteropServices.ComTypes;

namespace AdventOfCode2025;

public abstract class Day4
{
    public static int FindMovableRolls_Part1(string input)
    {
        var grid = input.Split(Environment.NewLine)
            .Select(c => c.ToArray()).ToArray();

        var movable = 0;

        for (var y = 0; y < grid.Length; y++)
        {
            var r = grid[y];

            for (var x = 0; x < r.Length; x++)
            {
                var val = grid[y][x];
                if (val == '.') continue;

                // get (up to) 8 surrounding squares and then count

                var rolls = 0;

                // top left
                if (y != 0 && x != 0)
                {
                    if (grid[y - 1][x - 1] == '@') rolls++;
                }

                // top middle
                if (y != 0)
                {
                    if (grid[y - 1][x] == '@') rolls++;
                }

                // top right
                if (y != 0 && x != r.Length - 1)
                {
                    if (grid[y - 1][x + 1] == '@') rolls++;
                }

                // middle left
                if (x != 0)
                {
                    if (grid[y][x - 1] == '@') rolls++;
                }

                // middle right
                if (x != r.Length - 1)
                {
                    if (grid[y][x + 1] == '@') rolls++;
                }

                // bottom left
                if (y != grid.Length - 1 && x != 0)
                {
                    if (grid[y + 1][x - 1] == '@') rolls++;
                }

                // bottom middle
                if (y != r.Length - 1)
                {
                    if (grid[y + 1][x] == '@') rolls++;
                }

                // bottom right
                if (y != r.Length - 1 && x != r.Length - 1)
                {
                    if (grid[y + 1][x + 1] == '@') rolls++;
                }

                if (rolls <= 3) movable++;
            }
        }

        return movable;
    }

    public static int FindMovableRolls_Part2(string input)
    {
        var grid = input.Split(Environment.NewLine)
            .Select(c => c.ToArray()).ToArray();

        var movedRolls = 0;
        var lastMoved = -1;
        var yMax = grid.Length;
        var xMax = grid[0].Length;
        int[] offsets = [-1, 0, 1];

        while (movedRolls != lastMoved)
        {
            lastMoved = movedRolls;

            for (var y = 0; y < yMax; y++)
            {
                for (var x = 0; x < xMax; x++)
                {
                    if (grid[y][x] != '@') continue;

                    var adjRolls = 0;
                    
                    foreach (var dy in offsets)
                    foreach (var dx in offsets)
                    {
                        if (dy is 0 && dx is 0) continue;

                        var ty = y + dy;
                        var tx = x + dx;

                        if (ty < 0 || ty >= yMax || tx < 0 || tx >= xMax) continue;
                        if (grid[ty][tx] == '@') adjRolls++;
                    }
                    
                    if (adjRolls > 3) continue;

                    movedRolls++;
                    grid[y][x] = '.';
                }
            }
        }

        return movedRolls;
    }
}