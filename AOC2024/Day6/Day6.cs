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
           // Move Guard and track path
           MoveGuard(guard);

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
            List<string> points = new();
            // Add Guard start position
            points.Add(string.Concat(guard.X, guard.Y)); 
            // While the guard is in the room move
            // ^ : row -1, > : col +1, v : row +1, < : col -1
            
            // CHeck boundaries
            bool guardInRoom = true;
            // while (guard.X < _room[0].Length && guard is { X: > 0, Y: > 0 } && guard.Y < _room.Length)
            while (guardInRoom)
            {
                // Check ahead, if cannot (#) move turn right, check ahead again
                // move in a direction, record position, then check ahead
                // repeat

                // record position here
                
                // Console.WriteLine($"Guard at ({guard.X},{guard.Y}): moving {guard.Direction} ");
                points.Add(string.Concat(guard.X, guard.Y));
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
                    Console.WriteLine($"\tGuard was in {points.Distinct().Count()} positions.");
                    Console.ResetColor();
                    guardInRoom = false;
                }
            }
        }
    }

    public class Guard
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }


    }
}
