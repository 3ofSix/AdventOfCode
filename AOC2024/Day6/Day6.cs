using System.Drawing;

namespace AOC2024.Day6
{
    public class Day6
    {
        private char[,] _room;
        private readonly char[] _guardDirection = ['^', '>', 'v', '<'];
        private readonly string[] _input;
        private Guard _guard;
        private int _blockers = 0;
        private const char Obstacle = 'O';

        public Day6(string filePath)
        {
            _input = File.ReadAllLines(filePath);
        }

        private void SetRoom()
        {
            // new char[rows, cols]
            _room = new char[_input.Length, _input.First().Length];
            
            _input.SelectMany((line, rowIndex) =>
                line.Select((character, colIndex) =>
                    new { rowIndex, colIndex, character }))
                .ToList()
                .ForEach(entry =>
                    _room[entry.rowIndex,entry.colIndex] = entry.character);
           
            _guard = FindGuard(); // Find Guard start coords
        }

        public void Part1()
        {
            SetRoom();
            MarkTheSpot(true); // set Guard position to an X
            while (_guard.Move(_room)) // While the guard can move
            { 
                MarkTheSpot(true); // set Guard position to an X
            }
            CountTheXs(); // Expected 4454
           // DrawRoom();
        }

        private void MarkTheSpot(bool useX, char marker = 'X')
        {
            if (!useX)
            {
                if (_guard.Direction == Direction.Up || _guard.Direction == Direction.Down)
                {
                    marker = '|';
                } else if (_guard.Direction == Direction.Left || _guard.Direction == Direction.Right)
                {
                    marker = '-';
                }
            }
            if (_room[_guard.X,_guard.Y] == '+')
            {
                _blockers++;
            }
            _room[_guard.X,_guard.Y] = marker;
        }

        public void Part2()
        {
             SetRoom();
             MarkTheSpot(false); // Guard is on the way up
            //
            // // Loop the room adding an obstacle
            // foreach (var row in _room)
            // {
            //     for (var y = 0; y < row.Length; y++)
            //     {
            //         SetRoom(); // Reset Room
            //         if (row[y] == '#') continue;
            //         row[y] = Obstacle; // Set the obstacle
            //         MoveGuard(false);
            //     }
            // }

            Console.WriteLine($"Part 2: Blockers: {_blockers}");
        }

        void DrawRoom()
        {
            for (int row = 0; row < _room.GetLength(0); row++)
            {
                for (int col = 0; col < _room.GetLength(1); col++)
                {
                    if(_room[row,col] != '.' && _room[row,col] != '#') Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{_room[row,col]} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------");
            Console.ResetColor();
        }

        private Guard? FindGuard()
        {
            for (var row = 0; row < _room.GetLength(0); row++)
            {
                for (var col = 0; col < _room.GetLength(1); col++)
                {
                    // Loop the guard!
                    foreach (var direction in _guardDirection)
                    {
                        if (direction == _room[row,col])
                        {
                            return new Guard(direction, row, col);
                        }
                    }
                }
            }

            return null;
        }

        

        private void CountTheXs()
        {
             int xCount = _room.Cast<char>().Count(c => c == 'X');
             Console.ForegroundColor = ConsoleColor.Magenta;
             Console.WriteLine($"\n\tNumber of Xs: {xCount}");
             Console.ResetColor();
        }
    }

    internal class InfiniteLoopException : Exception
    {
        public InfiniteLoopException()
        {
        }

        public InfiniteLoopException(string? message) : base(message)
        {
        }

        public InfiniteLoopException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}