using System.Drawing;

namespace AOC2024.Day6
{
    public class Day6
    {
        private readonly char[][] _room;
        private char[] _guardDirection = ['^', '>', 'v', '<'];

        public Day6(string filePath)
        {
            string[] Input = File.ReadAllLines(filePath);
            // Create the char[][] array (room)
            _room = Input.Select(line => line.ToCharArray()).ToArray();
        }

        public void Part1()
        {
            // Find Guard start coords
            // Find start direction
            Guard guard =  FindGuard();
            Console.WriteLine($"Guard starts at ({guard.X},{guard.Y}): moving {guard.Direction} ");
            // set Guard position to an X
            MarkTheSpot(guard);
           // Move Guard and track path
           MoveGuard(guard);
           CountTheXs();
        }

        private void MarkTheSpot(Guard guard)
        {
            _room[guard.X][guard.Y] = 'X';
        }

        public void Part2()
        {
            
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

        private void MoveGuard(Guard guard)
        {
            // While the guard is in the room move
            // ^ : row -1, > : col +1, v : row +1, < : col -1
            
            bool guardInRoom = true;
            while (guardInRoom)
            {
                // Check ahead, if cannot (#) move turn right, check ahead again
                // move in a direction, record position, then check ahead
                // repeat

                // Console.WriteLine($"Guard at ({guard.X},{guard.Y}): moving {guard.Direction} ");
                try
                {
                    switch (guard.Direction)
                                    {
                                        case '^':
                                            if (_room[guard.X - 1][guard.Y] != '#')
                                            {
                                                guard.X -= 1;
                                            }
                                            else
                                            {
                                                guard.Direction = '>';
                                            }
                                            break;
                                        case 'v':
                                            if (_room[guard.X + 1][guard.Y] != '#')
                                            {
                                                guard.X += 1;
                                            }
                                            else
                                            {
                                                guard.Direction = '<';
                                            }
                                            break;
                                        case '<':
                                            if (_room[guard.X][guard.Y - 1] != '#')
                                            {
                                                guard.Y -= 1;
                                            }
                                            else
                                            {
                                                guard.Direction = '^';
                                            }
                                            break;
                                        case '>':
                                            if (_room[guard.X][guard.Y + 1] != '#')
                                            {
                                                guard.Y += 1;
                                            }
                                            else
                                            {
                                                guard.Direction = 'v';
                                            }
                                            break;
                                        default:
                                            throw new Exception("Invalid direction");
                                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\tGuard has left the building!");
                    Console.ResetColor();
                    guardInRoom = false;
                }
                //Mark the spot
                MarkTheSpot(guard);
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
