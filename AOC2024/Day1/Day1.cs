namespace AOC2024.Day1;

public class Day1
{
    //Part 1 expected result 1506483
    // Part 2 Expected result 23126924
    // Read file to 2 int arrays
    // sort each array
    // iterate array collecting the distance between numbers
    // sum the numbers
    private string[] Input { get; init; }
    private List<int> list1 = new(); 
    private List<int> list2 = new();
    private List<int> distances = new();
    public Day1(string filePath)
    {
        this.Input = File.ReadAllLines(filePath);
    }

    public void PopulateLists()
    { 
        foreach (var line in Input)
        {
            var l = line.Split(' ');
            list1.Add(int.Parse(l[0]));
            list2.Add(int.Parse(l[1]));
        }
        list1.Sort();
        list2.Sort();

        for (int i = 0; i < list1.Count; i++)
        {
            distances.Add(list1[i] - list2[i]);
        }
        
        var sum = distances.Sum(n => n < 0 ? n * -1 : n);
        Console.WriteLine(sum);
        Similarity();
    }
    
    // Similarity list 
    public void Similarity()
    {
        // int[] left = [3,4,2,1,3,3];
        // int[] right = [4,3,5,3,9,3];

        var similarity = list1
            .ToLookup(num => num, num =>
            {
                return list2.Count(x => x == num) * num;
            })
            .SelectMany(group => group)
            .ToList()
            .Sum();
        Console.WriteLine(similarity);
    }
}