namespace AdventOfCode2025;

public static class Day5
{
    public static int FindFreshIngredients_Part1(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var emptyLine = lines.IndexOf(string.Empty);

        var freshIngredientRanges = lines[..emptyLine]
            .Select(c =>
            {
                var parts = c.Split('-');
                return (long.Parse(parts[0]), long.Parse(parts[1]));
            }).ToArray();

        return lines[(emptyLine + 1)..].Select(long.Parse).Count(id =>
            freshIngredientRanges.Any(r => id >= r.Item1 && id <= r.Item2));
    }

    public static long FindFreshIngredients_Part2(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var emptyLine = lines.IndexOf(string.Empty);

        var ranges = lines[..emptyLine]
            .Select(c =>
            {
                var parts = c.Split('-');
                return (Start: long.Parse(parts[0]), End: long.Parse(parts[1]));
            })
            .OrderBy(c => c.Start)
            .ToList();

        // COLLISION DETECTION
        // [------] {----} NO OVERLAP      --- add both separately
        // [---{---}---] FULL OVERLAP      --- add just the biggest
        // [---{--]----} PARTIAL OVERLAP   --- add the combined

        while (true)
        {
            List<(long Start, long End)> newRanges = [];

            for (var i = 0; i < ranges.Count; i++)
            {
                if (i == ranges.Count - 1)
                {
                    // Automatically include the last range
                    newRanges.Add(ranges[i]);
                    continue;
                }

                var curr = ranges[i];
                var next = ranges[i + 1];

                if (next.End <= curr.End)
                {
                    // FULL OVERLAP
                    newRanges.Add(curr);
                    i++;
                }
                else if (next.Start <= curr.End)
                {
                    // PARTIAL OVERLAP
                    newRanges.Add((curr.Start, next.End));
                    i++; // skip next
                }
                else
                {
                    // NO OVERLAP
                    newRanges.Add(curr);
                }
            }

            // No more collisions - escape
            if (ranges.Count == newRanges.Count) break;

            ranges = newRanges;
        }

        return ranges.Select(c => c.End - c.Start + 1).Sum();
    }
}