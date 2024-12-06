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
           // Move Guard and track path

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
                                x = x,
                                y = y,
                                direction = direction
                            };
                        }
                    }
                }
            }
            return null;
        }

        private void MoveGuard()
        {

        }

        
    }

    public class Guard
    {
        public int x { get; init; }
        public int y { get; init; }
        public char direction { get; init; }


    }
}
