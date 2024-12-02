namespace AOC2024.Day1;

// Total distance for sample = 11
// Similarity for sample = 31
public class Test
{
    public static void Run()
    {
        List<int> left = [3,4,2,1,3,3];
        List<int> right = [4,3,5,3,9,3];
        
        // For Part 1 distance sort 
        left.Sort();
        right.Sort();
        Console.WriteLine("===");
        left.Select(l => l * 2).ToList().ForEach(l => Console.Write(l));
        Console.WriteLine("===");
        // Calculate the distances and store in a new list
        // List<int> distances = left.Select((value, index) => Math.Abs(value - right[index])).ToList();
        // // Print the distances to the console
        // distances.ForEach(distance => Console.WriteLine(distance));
        left.Select(l => right.Select(r => l - r)).ToList().ForEach(l => Console.Write(l));
        Console.WriteLine("===");

        var distances = left
            .Select((value, index) => Math.Abs(value - right[index]))
            .ToList()
            .Sum();
        Console.WriteLine($"Distances: {distances}");

        var similarity = left
            .ToLookup(num => num, num =>
            {
                return right.Count(x => x == num) * num;
            })
            .SelectMany(group => group)
            .ToList()
            .Sum();
        Console.WriteLine(similarity);
    }
}