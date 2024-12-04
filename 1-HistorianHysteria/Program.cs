List<int> left = [];
List<int> right = [];
List<int> distances = [];
List<int> similarities = [];

foreach (var line in File.ReadAllLines("real-input.txt"))
{
    var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    left.Add(int.Parse(parts[0]));
    right.Add(int.Parse(parts[1]));
}

left = left.Order().ToList();
right = right.Order().ToList();

for (var i = 0; i < left.Count; i++)
{
    distances.Add(Math.Abs(left[i] - right[i]));
}

var totalDistance = distances.Sum();

Console.WriteLine("The total distance is {0}", totalDistance);

for (var i = 0; i < left.Count; i++)
{
    var number = left[i];
    var occurrences = right.Count(c => c == number);
    similarities.Add(number * occurrences);
}

var similarityScore = similarities.Sum();

Console.WriteLine("The similarity score is {0}", similarityScore);
