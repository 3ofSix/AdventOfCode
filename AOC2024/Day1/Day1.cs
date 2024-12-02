namespace AOC2024.Day1;

public class Day1
{
    //Part 1 expected result 1506483
    // Part 2 Expected result 23126924
    // Read file to 2 int arrays
    // sort each array
    // iterate array collecting the distance between numbers
    // sum the numbers
    
    private readonly List<int> _left; 
    private readonly List<int> _right;
    
    public Day1(string filePath)
    {
        string[] input = File.ReadAllLines(filePath);
        _left = input.Select(line => int.Parse(line.Split()[0])).ToList();
        _right = input.Select(line => int.Parse(line.Split()[1])).ToList();
        
        _left.Sort();
        _right.Sort();
    }

    public void Part1()
    { 
        var distances = _left
            .Select((value, index) => Math.Abs(value - _right[index]))
            .ToList()
            .Sum();
        Console.WriteLine($"Distances: {distances}");
    }
    
    // Similarity list 
    public void Part2()
    {
        var similarity = _left
            .ToLookup(num => num, num =>
            {
                return _right.Count(x => x == num) * num;
            })
            .SelectMany(group => group)
            .ToList()
            .Sum();
        Console.WriteLine($"Similarity : {similarity}");
    }
}