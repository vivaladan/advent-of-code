namespace AdventOfCode2025;

public abstract class Day2
{
    public static long CountInvalidIds_Part1(string input)
    {
        long idSum = 0;

        foreach (var range in input.Split(',').Where(c => !string.IsNullOrWhiteSpace(c)))
        {
            var rangeParts = range.Split('-');
            var rangeStart = long.Parse(rangeParts[0]);
            var rangeEnd = long.Parse(rangeParts[1]);

            for (var id = rangeStart; id <= rangeEnd; id++)
            {
                var idStr = id.ToString();
                if (idStr.Length % 2 != 0) continue;

                var firstHalf = idStr[..(idStr.Length / 2)];
                var secondHalf = idStr[(idStr.Length / 2)..];

                if (firstHalf == secondHalf)
                {
                    idSum += id;
                }
            }
        }

        return idSum;
    }


    public static long CountInvalidIds_Part2(string input)
    {
        // maybe not the most performant way to do this?
        return input.Split(',')
            .Where(c => !string.IsNullOrWhiteSpace(c))
            .SelectMany(c =>
            {
                var rangeParts = c.Split('-');
                var rangeStart = long.Parse(rangeParts[0]);
                var rangeEnd = long.Parse(rangeParts[1]);
                // sadly Range doesn't work with long
                return Enumerable.Range(0, (int)(rangeEnd - rangeStart + 1)).Select(i => i + rangeStart);
            })
            .Where(id =>
            {
                var idStr = id.ToString();

                return Enumerable.Range(2, idStr.Length - 1)
                    .Where(i => idStr.Length % i == 0)
                    .Any(chunkCount =>
                    {
                        var chunkSize = idStr.Length / chunkCount;
                        var firstPart = idStr[..chunkSize];
                        return Enumerable.Range(1, chunkCount - 1)
                            .All(c => idStr.Substring(c * chunkSize, chunkSize) == firstPart);
                    });
            })
            .Sum();
    }
}