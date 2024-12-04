var safeReports = File.ReadAllLines("test-input.txt")
    .Select(report => report.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList())
    .Count(AreLevelsSafe);

Console.WriteLine("There are {0} safe reports", safeReports);
return;

bool AreLevelsSafe(IList<int> levels)
{
    var startingDirection = Math.Sign(levels[0] - levels[1]);
    var strikes = 0;
    
    for (var i = 0; i < levels.Count - 1; i++)
    {
        var delta = levels[i] - levels[i + 1];
        
        if (Math.Sign(delta) != startingDirection || Math.Abs(delta) is < 1 or > 3)
        {
            if (--strikes >= 0)
            {
                return false;
            }
            else
            {
                i++;
            }
        }
    }

    return strikes >= 0;

    //return true;
}
