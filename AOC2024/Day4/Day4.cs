namespace AOC2024.Day4
{
    public class Day4
    {
        private readonly char[][] _grid;
        public Day4(string filePath)
        {
            string[] Input = File.ReadAllLines(filePath);
            // Create the char[][] array (grid)
            _grid = Input.Select(line => line.ToCharArray()).ToArray();
        }

        public void Part1(string word)
        {
            List<int[]> ans = searchWord(_grid, word);

            printResult(ans);

        }

        public void Part2()
        {
            Console.WriteLine($"Day4 part2 found {Search("MAS")} X's");
        }
        // This function searches for the given word
        // in all 8 directions from the coordinate.
        static int search2D(char[][] grid, int row, int col, string word)
        {
            int found = 0;
            int m = grid.Length;
            int n = grid[0].Length;

            // return false if the given coordinate
            // does not match with first index char.
            if (grid[row][col] != word[0])
                return found;

            int len = word.Length;

            // x and y are used to set the direction in which
            // word needs to be searched.
            int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };

            // This loop will search in all the 8 directions
            // one by one. It will return true if one of the 
            // directions contain the word.
            for (int dir = 0; dir < 8; dir++)
            {

                // Initialize starting point for current direction
                int k, currX = row + x[dir], currY = col + y[dir];

                // First character is already checked, match remaining
                // characters
                for (k = 1; k < len; k++)
                {

                    // break if out of bounds
                    if (currX >= m || currX < 0 || currY >= n || currY < 0)
                        break;

                    // break if characters dont match
                    if (grid[currX][currY] != word[k])
                        break;

                    // Moving in particular direction
                    currX += x[dir];
                    currY += y[dir];
                }

                // If all character matched, then value of must
                // be equal to length of word
                if (k == len) found++; //return true;
            }

            // if word is not found in any direction,
            // then return false
            return found;
        }

        // This function calls search2D for each coordinate
        static List<int[]> searchWord(char[][] grid, string word)
        {
            int foundWords = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            List<int[]> ans = new List<int[]>();

            // if the word is found from this coordinate,
            // then append it to result.
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    //if (search2D(grid, i, j, word))
                    //{
                    //    ans.Add(new int[] { i, j });
                    //}
                    foundWords += search2D(grid, i, j, word);
                }
            }
            Console.WriteLine($"Found {word} {foundWords} times");
            return ans;
        }

        static void printResult(List<int[]> ans)
        {
            foreach (var coord in ans)
            {
                Console.Write("{" + coord[0] + "," + coord[1] + "}" + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Total: {ans.Count}");
        }

        int Search(string word)
        {
            int foundX = 0;
            
            // Iterate grid searching for word
            for (int row = 0; row < _grid.Length; row++)
            {
                for (int col = 0; col < _grid[0].Length; col++)
                {
                    if (searchX(row, col, word))
                    {
                        foundX++;
                        Console.WriteLine($"\tFound {word} {foundX} times at row {row}, col {col}");
                    }
                }
            }
            return foundX;
        }

        private bool searchX(int row, int col, string word)
        {
            // x and y are used to set the direction in which
            // word needs to be searched.
            // remember rows ar increasing as they go down
            int[] x = { -1, 1, 1, -1 }; // col
            int[] y = {  1,-1, 1, -1 }; // row
            
            // check for A
            if (_grid[row][col] != word[1])
                return false;
            // Search for M, S in each direction of X from A
            
            // If grid[row][col] letter is A ASSUME word is MAS
            
                // set up down left, up right, dowm right, up left
                int xdl = col + x[0], ydl = row + y[0];
                int xur = col + x[1], yur = row + y[1];
                int xdr = col + x[2], ydr = row + y[2];
                int xul = col + x[3], yul = row + y[3];
                
            // break if out of bounds
            // check x
            if (xdl < 0 || xul < 0 || xur >= _grid[0].Length || xdr >= _grid[0].Length)
                return false;
            // check y
            if (ydl < 0 || yul < 0 || yur >= _grid.Length || ydr >= _grid.Length)
                return false;

            // for each direction check for M or S
            return (
                       ((_grid[ydl][xdl] == word[0] && _grid[yur][xur] == word[2]) || (_grid[ydl][xdl] == word[2] && _grid[yur][xur] == word[0]))
                   && 
                       ((_grid[ydr][xdr] == word[0] && _grid[yul][xul] == word[2]) || (_grid[ydr][xdr] == word[2] && _grid[yul][xul] == word[0]))
                       );
        }
    }
}
