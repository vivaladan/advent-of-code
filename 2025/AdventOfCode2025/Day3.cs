using System.Collections.Immutable;
using System.Diagnostics;

namespace AdventOfCode2025;

public abstract class Day3
{
    public static int FindMaximumJoltage_Part1(string input)
    {
        var vals = input
            .Split(Environment.NewLine)
            .Select(bank =>
            {
                var vals = bank.Select(v => int.Parse(v.ToString())).ToImmutableArray().AsSpan();
                var first = FindHighestValueInBank(vals[..^1]);
                var second = FindHighestValueInBank(vals[(first.idx + 1)..]);
                var res = first.val * 10 + second.val;
                Debug.WriteLine(res);
                return res;
            })
            .ToList();

        return vals.Sum();


        (int val, int idx) FindHighestValueInBank(ReadOnlySpan<int> bank)
        {
            var hVal = 0;
            var hIdx = 0;

            for (var i = 0; i < bank.Length; i++)
            {
                var cVal = int.Parse(bank[i].ToString());
                if (cVal <= hVal) continue;

                hVal = cVal;
                hIdx = i;
            }

            return (hVal, hIdx);
        }
    }

    public static long FindMaximumJoltage_Part2(string input)
    {
        var vals = input
            .Split(Environment.NewLine)
            .Select(bank =>
            {
                var vals = bank.Select(v => int.Parse(v.ToString())).ToArray();
                var lBound = 0;

                return Enumerable.Range(1, 12).Reverse()
                    .Select(rBound =>
                    {
                        var next = FindHighestValueInBank(vals.AsSpan()[lBound..^(rBound - 1)]);
                        lBound += next.idx + 1;
                        return next.val;
                    })
                    .Aggregate<int, long>(0, (current, digit) => current * 10 + digit);
            })
            .ToList();

        return vals.Sum();


        (int val, int idx) FindHighestValueInBank(ReadOnlySpan<int> bank)
        {
            var hVal = 0;
            var hIdx = 0;

            for (var i = 0; i < bank.Length; i++)
            {
                var cVal = int.Parse(bank[i].ToString());
                if (cVal <= hVal) continue;

                hVal = cVal;
                hIdx = i;
            }

            return (hVal, hIdx);
        }
    }
}