namespace AOC2024.Day15;

public class Day15
{
    private char[,] _map;
    private char[] _robotMoves;
    private (int,int) _robotPosition;
    private readonly Dictionary<char, (int dx, int dy)> _directionVectors = new() 
    {
        { '^', (-1, 0) },
        { '>', (0, 1) },
        { 'v', (1, 0) },
        { '<', (0, -1) }
    };
    public Day15(string filePath)
    {
        var parts = File.ReadAllText(filePath).Split("\n\n");
        
        _robotMoves = parts[1].ToCharArray();

        var mapLines = parts[0].Split("\n");
        
        _map = new char[mapLines.Length, mapLines.First().Length];
        
        // Read file into 2D array
        
        mapLines.SelectMany((line, rowIndex) =>
                line.Select((character, colIndex) =>
                    new { rowIndex, colIndex, character }))
            .ToList()
            .ForEach(entry =>
                _map[entry.rowIndex, entry.colIndex] = entry.character);
    }

    public void Part1()
    {
        // Find the robot '@'
        _robotPosition = GetRobotPosition();
        // Start moving the robot
        foreach (char move in _robotMoves)
        {
            // get direction vector
            if (move == '\n') continue;
            
            var (dx,dy) = _directionVectors[move];
            Move('@', _robotPosition, (dx, dy));
            
            // Check can move
            // update position
            // check empty '.' Dont care about array bounds because '#' is a wall
        } 
        Console.WriteLine($"Part1: GPS sum {SumBoxGPS()}");
    }
    
    public void Part2()
    {
        Console.WriteLine("Part2 not solved");
    }

    private (int, int) GetRobotPosition()
    {
        for (int row = 0; row < _map.GetLength(0); row++)
        {
            for (int col = 0; col < _map.GetLength(0); col++)
            {
                if (_map[row, col] == '@') return (row, col);
            }
        }
        return (-1, -1); // Not found!
    }

    private bool Move(char obj, (int, int) position, (int, int) direction)
    {
        // Recursion remember Inception
        // set new
        int newX = position.Item1 + direction.Item1;
        int newY = position.Item2 + direction.Item2;
        
        // The kick
        if (_map[newX, newY] == '#') return false;
        
        // If new position is a box check if box can move
        if (_map[newX, newY] == 'O')
        {
            if(!Move('O', (newX, newY), direction)) return false;
        }
        
        // Assume we can move update the positions
            _map[position.Item1,position.Item2] = '.';
        // Are you a robot?
        if (obj == '@')
        {
            _robotPosition = (newX, newY);
            _map[newX, newY] = '@';
        }
        // Is this a box?
        else if (obj == 'O')
        {
            _map[newX, newY] = 'O';
        }
        
        return true;
    }

    private int SumBoxGPS()
    {
        int sum = 0;
        for (int row = 0; row < _map.GetLength(0); row++)
        {
            for (int col = 0; col < _map.GetLength(1); col++)
            {
                if (_map[row, col] == 'O')
                {
                    sum += 100 * row + col;
                }
            }
        }
        return sum;
    }
}