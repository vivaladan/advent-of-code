using System.Diagnostics;

namespace AdventOfCode2025;

public static class Day1
{
    public static string GetPwdFromSeq_Part1(string[] seq)
    {
        var dial = 50;
        var zeroCount = 0;

        Debug.WriteLine($"The dial starts by pointing at 50.");

        foreach (var rot in seq)
        {
            var val = int.Parse(rot[1..]);

            val %= 100;

            switch (rot[0])
            {
                case 'L':
                {
                    var dec = dial - val;
                    if (dec < 0)
                    {
                        dial = dec + 100;
                    }
                    else
                    {
                        dial = dec;
                    }

                    break;
                }
                case 'R':
                {
                    var inc = dial + val;
                    if (inc > 99)
                    {
                        dial = inc - 100;
                    }
                    else
                    {
                        dial = inc;
                    }

                    break;
                }
            }

            Debug.WriteLine($"The dial is rotated {rot} to point at {dial}");

            if (dial == 0)
            {
                zeroCount++;
            }
        }

        return zeroCount.ToString();
    }

    public static string GetPwdFromSeq_Part2(string[] seq)
    {
        var dial = 50;
        var zeroCount = 0;

        foreach (var rot in seq)
        {
            var clicks = int.Parse(rot[1..]);

            // Each full rotation past 0 counts as an additional zero
            zeroCount += clicks / 100;

            // Only the remainder affects the dial position
            clicks %= 100;

            switch (rot[0])
            {
                case 'L':
                {
                    var left = dial - clicks;
                    if (left < 0)
                    {
                        // When prev rotation ends at 0, we have already counted that zero
                        if (dial != 0) zeroCount++;
                    
                        // Wrap around
                        dial = left + 100;
                    }
                    else
                    {
                        dial = left;
                        if (dial == 0) zeroCount++;
                    }

                    break;
                }
                case 'R':
                {
                    var right = dial + clicks;
                    if (right > 99)
                    {
                        // When prev rotation ends at 0, we have already counted that zero
                        if (dial != 0) zeroCount++;

                        // Wrap around
                        dial = right - 100;
                    }
                    else
                    {
                        dial = right;
                        if (dial == 0) zeroCount++;
                    }

                    break;
                }
            }
        }

        return zeroCount.ToString();
    }

}
