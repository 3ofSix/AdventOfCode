using System.Drawing;

namespace AOC2024.Day6
{
    public class Day6
    {
        private char[][] _room;
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
            _room = _input.Select(line => line.ToCharArray()).ToArray(); // Create the char[][] array (room)
            _guard = FindGuard(); // Find Guard start coords
        }

        public void Part1()
        {
            SetRoom();
            MarkTheSpot(); // set Guard position to an X
            MoveGuard(true); // Move Guard and track path
            CountTheXs(); // Expected 4454
        }

        private void MarkTheSpot(char marker = 'X')
        {
            _room[_guard.X][_guard.Y] = marker;
        }

        public void Part2()
        {
            SetRoom();
            MarkTheSpot('|'); // Guard is on the way up
            for (int row = 0; row < _room.Length; row++)
            {
                for (int col = 0; col < _room[row].Length; col++)
                {
                    SetRoom(); // Reset Room
                    if (_room[row][col] == '#') continue;
                    _room[row][col] = Obstacle; // Set the obstacle
                    MoveGuard(false);
                    //DrawRoom();
                }
            }
            // Loop the room adding an obstacle
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
            foreach (var row in _room)
            {
                foreach (var col in row)
                {
                    if (col != '.' && col != '#') Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{col} ");
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
            for (var x = 0; x < _room.Length; x++)
            {
                for (var y = 0; y < _room[x].Length; y++)
                {
                    // Loop the guard!
                    foreach (var direction in _guardDirection)
                    {
                        if (direction == _room[x][y])
                        {
                            return new Guard
                            {
                                X = x,
                                Y = y,
                                Direction = direction
                            };
                        }
                    }
                }
            }

            return null;
        }

        private void MoveGuard(bool useX)
        {
            // While the guard is in the room move
            // ^ : row -1, > : col +1, v : row +1, < : col -1
            while (true)
            {
                // Check ahead, if cannot (# || O) move turn right, check ahead again
                // move in a direction, record position, then check ahead
                // repeat

                var debugCheck = _room[_guard.X][_guard.Y];
                if (_room[6][3] == Obstacle)
                {
                    bool stop;
                }

                try
                {
                    switch (_guard.Direction)
                    {
                        case '^':
                            if (_room[_guard.X - 1][_guard.Y] == '+') throw new InfiniteLoopException();
                            if (_room[_guard.X - 1][_guard.Y] != '#' && _room[_guard.X - 1][_guard.Y] != Obstacle)
                            {
                                _guard.X -= 1;
                                MarkTheSpot(useX ? 'X' : '|');
                            }
                            else
                            {
                                _guard.Direction = '>';
                                if (!useX) MarkTheSpot('+');
                            }

                            break;
                        case 'v':
                            if (_room[_guard.X + 1][_guard.Y] == '+') throw new InfiniteLoopException();
                            if (_room[_guard.X + 1][_guard.Y] != '#' && _room[_guard.X + 1][_guard.Y] != Obstacle)
                            {
                                _guard.X += 1;
                                MarkTheSpot(useX ? 'X' : '|');
                            }
                            else
                            {
                                _guard.Direction = '<';
                                if (!useX) MarkTheSpot('+');
                            }

                            break;
                        case '<':
                            if (_room[_guard.X][_guard.Y - 1] == '+') throw new InfiniteLoopException();
                            if (_room[_guard.X][_guard.Y - 1] != '#' && _room[_guard.X][_guard.Y - 1] != Obstacle)
                            {
                                _guard.Y -= 1;
                                MarkTheSpot(useX ? 'X' : '-');
                            }
                            else
                            {
                                _guard.Direction = '^';
                                if (!useX) MarkTheSpot('+');
                            }

                            break;
                        case '>':
                            if (_room[_guard.X][_guard.Y + 1] == '+') throw new InfiniteLoopException();
                            if (_room[_guard.X][_guard.Y + 1] != '#' && _room[_guard.X][_guard.Y + 1] != Obstacle)
                            {
                                _guard.Y += 1;
                                MarkTheSpot(useX ? 'X' : '-');
                            }
                            else
                            {
                                _guard.Direction = 'v';
                                if (!useX) MarkTheSpot('+');
                            }

                            break;
                        default:
                            throw new Exception("Invalid direction");
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    // Console.ForegroundColor = ConsoleColor.Green;
                    // Console.WriteLine($"\n\tGuard has left the building!");
                    // Console.ResetColor();
                    break;
                }
                catch (InfiniteLoopException)
                {
                    Console.WriteLine("Infinite loop detected");
                    _blockers++;
                    DrawRoom();
                    break;
                }
            }
        }

        private void CountTheXs()
        {
            int countX = _room.SelectMany(line => line).Count(c => c == 'X');
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n\tNumber of Xs: {countX}");
            Console.ResetColor();
        }
    }

    internal class InfiniteLoopException : Exception
    {
        public InfiniteLoopException()
        {
        }

        public InfiniteLoopException(string message)
            : base(message)
        {
        }

        public InfiniteLoopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class Guard
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }
    }
}