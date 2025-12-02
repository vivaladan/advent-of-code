namespace AdventOfCode2025.Tests;

public class TestBase
{
    private static string ProjectDir => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

    protected static string LoadFromFile(string fileName) =>
        File.ReadAllText(Path.Combine(ProjectDir, fileName));

    protected static string[] LoadLinesFromFile(string filename) =>
        File.ReadAllLines(Path.Combine(ProjectDir, filename))
            .Where(c => !string.IsNullOrWhiteSpace(c))
            .Select(c => c.Trim())
            .ToArray();
}