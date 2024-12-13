namespace AOC2024.Day6;

public class Guard
{
    private Direction _direction;
    public int X { get; set; }
    public int Y { get; set; }
    private HashSet<(int, int, Direction)> _visitedState = new();

    public Guard(char initialDirection, int startX, int startY)
    {
        _direction = (Direction)initialDirection;
        X = startX;
        Y = startY;
    }
    
    public Direction Direction => _direction;
    
    // Dictionary to store direction vectors
    private readonly Dictionary<Direction, (int dx, int dy)> _directionVectors = new() 
    {
        { Direction.Up, (-1, 0) },
        { Direction.Right, (0, 1) },
        { Direction.Down, (1, 0) },
        { Direction.Left, (0, -1) }
    };

    public void Turn()
    {
        switch (_direction)
        {
            case Direction.Up:
                _direction = Direction.Right;
                break;
            case Direction.Right:
                _direction = Direction.Down;
                break;
            case Direction.Down:
                _direction = Direction.Left;
                break;
            case Direction.Left:
                _direction = Direction.Up;
                break;
        }
    }

    public bool Move(char[,] room)
    {
        var (dx, dy) = _directionVectors[_direction];
        int newX = X + dx;
        int newY = Y + dy;

        // Deja Vu! Have I faced here before?
        if (_visitedState.Contains((newX, newY, _direction)))
        {
            Console.WriteLine("INFINITE {0} is already visited.", _direction);
            return false;
        }
        // Check boundaries. Has the guard left the room?
        if (newX < 0 || newY < 0 || newX >= room.GetLength(0) || newY >= room.GetLength(1))
        {
            Console.WriteLine("Guard left the room");
            return false;
        }

        if (room[newX,newY] != '#')
        {
           X = newX;
           Y = newY;
        }
        else
        {
            Turn();
        }
        return true;
    }
}

public enum Direction
{
    Up = '^',
    Right = '>',
    Down = 'v',
    Left = '<'
}