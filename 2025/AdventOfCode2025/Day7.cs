using System.Collections.Immutable;

namespace AdventOfCode2025;

public class Day7
{
    public static int Part1(string input)
    {
        var grid = input
            .Split(Environment.NewLine)
            .Select(c => c.ToArray())
            .ToArray();

        var yMax = grid.Length;
        var xMax = grid[0].Length;

        const int startY = 0;
        var startX = grid[0].IndexOf('S');

        List<(int y, int x)> beams = [(startY, startX)];

        var splits = 0;

        for (var y = 0; y < yMax - 1; y++)
        {
            for (var x = 0; x < xMax; x++)
            {
                if (grid[y][x] == 'S')
                {
                    // push starting beam down
                    grid[y + 1][x] = '|';
                }

                if (grid[y][x] != '|') continue;
                
                switch (grid[y + 1][x])
                {
                    case '.':
                        grid[y + 1][x] = '|';
                        break;
                    case '^':
                    {
                        // a beam has hit a splitter
                        splits++;
                        if (grid[y + 1][x - 1] == '.') grid[y + 1][x - 1] = '|';
                        if (grid[y + 1][x + 1] == '.') grid[y + 1][x + 1] = '|';
                        break;
                    }
                }
            }
        }

        return splits;
    }

    public static long Part2(string input)
    {
        // top down tree search with caching (otherwise 2^1747 branches)
        
        var grid = input
            .Split(Environment.NewLine)
            .Select(c => c.ToArray())
            .ToArray();

        var yMax = grid.Length;

        Dictionary<(int y, int x), long> cache = new();
        return CountPaths(1, grid[0].IndexOf('S'));

        long CountPaths(int y, int x)
        {
            if (y == yMax) return 1;
            if (cache.TryGetValue((y, x), out var val)) return val;
            
            var res = grid[y][x] switch
            {
                '.' => CountPaths(y + 1, x),
                '^' => CountPaths(y, x - 1) + CountPaths(y, x + 1),
                _ => throw new ArgumentOutOfRangeException()
            };

            cache.Add((y,x), res);
            return res;
        }
    }
}