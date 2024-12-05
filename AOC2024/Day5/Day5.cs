namespace AOC2024.Day5;

public class Day5
{
    private readonly string[] _rules;
    private readonly string[] _updates;
    public Day5(string input) 
    {
        // read the input
        string[] lines = File.ReadAllLines(input);
        // Get the empty line
        int indexOfEmptyLine = Array.IndexOf(lines, "");
        _rules = lines.Take(indexOfEmptyLine).ToArray();
        _updates = lines.Skip(indexOfEmptyLine + 1).ToArray();
    }

    public void Part1()
    {
        // iterate each update
        // join second number to first to match the rules pattern 32|14 second|first
        // if rules array contains the pattern then numbers need to be swapped
        // eg: if(_rules.Contains(second|first)
        
        // array to sort _updates[]
        int sum = 0;
        foreach (string update in _updates)
        {
            string[] line = update.Split(',');
            string[] original = update.Split(',');
            bool isSorted = original.SequenceEqual(sort(line));
            if (isSorted)
            {
                sum += Convert.ToInt32(original[original.Length / 2]);
            }
        }
        Console.WriteLine($"\tSum of middle pages : {sum}");

    }

    public void Part2()
    {
        int sum = 0;
        
        foreach (string update in _updates)
        {
            string[] line = update.Split(',');
            string[] original = update.Split(',');
            bool isSorted = original.SequenceEqual(sort(line));
            if (!isSorted)
            {
                sum += Convert.ToInt32(line[line.Length / 2]);
            }
        }
        Console.WriteLine($"\tSum of newly sorted middle pages : {sum}");
    }

    string[] sort(string[] line)
    {
        // iterate each update
        // join second number to first to match the rules pattern 32|14 second|first
        // if rules array contains the pattern then numbers need to be swapped
        // eg: if(_rules.Contains(second|first)
        
        // array to sort _updates[]
        for (int i = 1; i < line.Length; i++)
        {
            string second = line[i];
            int j = i - 1;
            
            /* Move elements of _updates[0...i-1] that are in the rules to one position ahead of current */
            while (j >= 0 && (_rules.Contains(string.Concat(second, "|", line[j]))))
            {
                line[j + 1] = line[j];
                j = j - 1;
            }
            line[j + 1] = second;
        }
        return line;
    }
    
}