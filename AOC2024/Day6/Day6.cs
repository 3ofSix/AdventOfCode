using System.Drawing;

namespace AOC2024.Day6
{
    public class Day6
    {
        private char[][] _room;
        private char[] _guardDirection = ['^', '>', 'v', '<'];
        private string[] _input;
        private Guard _guard;
        private int _blockers = 0;

        public Day6(string filePath)
        {
            _input = File.ReadAllLines(filePath);
        }

        private void SetRoom()
        {
            // Create the char[][] array (room)
            _room = _input.Select(line => line.ToCharArray()).ToArray();
            // Find Guard start coords
            // Find start direction
            _guard =  FindGuard();
            // Console.WriteLine($"Guard starts at ({_guard.X},{_guard.Y}): moving {_guard.Direction} ");
        }

        public void Part1()
        {
            SetRoom();
            // set Guard position to an X
            MarkTheSpot();
           // Move Guard and track path
           MoveGuard(true);
           CountTheXs(); // Expected 4454
        }

        private void MarkTheSpot(char marker = 'X')
        {
            _room[_guard.X][_guard.Y] = marker;
        }

        public void Part2()
        {
            // Reset Room
            SetRoom();
            
            
            // set Guard position to an | becuase the guard is initially going up!
            // DrawRoom();
            MarkTheSpot('|');
            
            // Loop the room adding an obstacle
            for (int x = 0; x < _room.Length; x++)
            {
                for (int y = 0; y < _room[x].Length; y++)
                {
                    SetRoom();
                    _room[x][y] = 'O';
                    // Move Guard and track path
                    MoveGuard(false);
                   
                    // Obstacle to this coordinate
                    // start moving Guard
                }
            }
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
            for (int x = 0; x < _room.Length; x++)
            {
                for (int y = 0; y < _room[x].Length; y++)
                {
                    // Loop the guard!
                    foreach (var direction in _guardDirection)
                    {
                        if(direction == _room[x][y])
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
            char marker = 'X';
            bool guardInRoom = true;
            while (guardInRoom)
            {
                // Check ahead, if cannot (#) move turn right, check ahead again
                // move in a direction, record position, then check ahead
                // repeat
                
                bool isChangeDirection = false;
                // Console.WriteLine($"Guard at ({guard.X},{guard.Y}): moving {guard.Direction} ");
                try
                {
                    switch (_guard.Direction) 
                    { 
                        case '^':
                        if (_room[_guard.X - 1][_guard.Y] != '#' && _room[_guard.X - 1][_guard.Y] != 'O')
                        {
                            _guard.X -= 1;
                            marker = useX ? 'X' : '|';
                        }
                        else
                        {
                            _guard.Direction = '>';
                            isChangeDirection = true;
                            marker = useX ? 'X' : '+';
                        }
                        break;
                    case 'v':
                        if (_room[_guard.X + 1][_guard.Y] != '#' && _room[_guard.X + 1][_guard.Y] != 'O')
                        {
                            _guard.X += 1;
                            marker = useX ? 'X' : '|';
                        }
                        else
                        {
                            _guard.Direction = '<';
                            isChangeDirection = true;
                            marker = useX ? 'X' : '+';
                        }
                        break;
                    case '<':
                        if (_room[_guard.X][_guard.Y - 1] != '#' && _room[_guard.X][_guard.Y - 1] != 'O')
                        {
                            _guard.Y -= 1;
                            marker = useX ? 'X' : '-';
                        }
                        else
                        {
                            _guard.Direction = '^';
                            isChangeDirection = true;
                            marker = useX ? 'X' : '+';
                        }
                        break;
                    case '>':
                        if (_room[_guard.X][_guard.Y + 1] != '#' && _room[_guard.X][_guard.Y + 1] != 'O')
                        {
                            _guard.Y += 1;
                            marker = useX ? 'X' : '-';
                        }
                        else
                        {
                            _guard.Direction = 'v';
                            isChangeDirection = true;
                            marker = useX ? 'X' : '+';
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
                    guardInRoom = false;
                }
                //Mark the spot
                if (isChangeDirection && !useX)
                {
                    if (_room[_guard.X][_guard.Y] == '+')
                    {
                        // Console.WriteLine($"\n\tBeen here before!");
                        _blockers++;
                        Console.WriteLine($"Part 2: Blockers: {_blockers}");
                        // DrawRoom();
                        break;
                    }
                    MarkTheSpot(marker);
                }
                if(!isChangeDirection) MarkTheSpot(marker);
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

    public class Guard
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }


    }
}
