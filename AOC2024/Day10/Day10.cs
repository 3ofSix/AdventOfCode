namespace AOC2024.Day10;

public class Day10
{
    private int[,] _map;
    private HashSet<(int,int)> _visited9 = new();
    public Day10(string filePath)
    {
        var input = File.ReadAllLines(filePath);
        
        _map = new int[input.Length, input.First().Length];
        
        // Read file into 2D array

        input.SelectMany((line, rowIndex) =>
                line.Select((character, colIndex) =>
                    new { rowIndex, colIndex, character }))
            .ToList()
            .ForEach(entry =>
                _map[entry.rowIndex, entry.colIndex] = 
                    entry.character == '.' ? -1 : int.Parse(entry.character.ToString()));
    }

    public void Part1()
    {
        int trailHeads = 0;
        // For each row find 0
        for (int row = 0; row < _map.GetLength(0); row++)
        {
            for (int col = 0; col < _map.GetLength(1); col++)
            {
                if (_map[row, col] == 0)
                {
                    
                    var paths = SearchPaths(row,col,1);
                    trailHeads += paths;
                    Console.WriteLine($"Trail head @{row},{col} has {paths} paths. Trail heads total of {trailHeads}");
                    _visited9.RemoveWhere(tuple => tuple.Item1 != -1 && tuple.Item2 != -1); // empty the _visiteed Set
                }
            }
        }
        Console.WriteLine("Done");
        Console.WriteLine($"Trail heads: {trailHeads}");
        // For each zero found find a path to 9
        // Record the trail head 
        // Find any additional paths 
        // record trail head score
        
        // Expect 472
    }

    public void Part2()
    {
        // Expect 969
    }
    
    private int SearchPaths(int startRow, int startCol, int nextValue)
    {
        if (nextValue > 9) return 1;
            //return _visited9.Add((startRow, startCol)) ? 1 : 0;
        
        
        int pathCount = 0;
        // Directions: up, right, down, left
        (int row, int col)[] directions = { (-1, 0), (0, 1), (1, 0), (0, -1) }; 
        foreach (var (dRow, dCol) in directions) 
        { 
            int newRow = startRow + dRow; 
            int newCol = startCol + dCol; 
            if (IsValidPosition(newRow, newCol) && _map[newRow, newCol] == nextValue) 
            { 
                //Console.WriteLine($"Found {nextValue} at ({newRow}, {newCol})"); 
                pathCount +=SearchPaths(newRow, newCol, nextValue + 1); 
               // return pathCount; // If you want to stop after finding the next number
            } 
        }
        return pathCount;
    }

    private bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < _map.GetLength(0) && col >= 0 && col < _map.GetLength(1);
    }
}