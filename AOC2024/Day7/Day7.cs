using System.Drawing;

namespace AOC2024.Day7
{
    public class Day7
    {
        /*
         * 2 numbers +,*
         * 3 numbers ++,+*,**,*+
         * 4 numbers +++,++*,+**,***,**+,*++,*+*,+*+
         *
         * So 2^(n-1) combinations where n is the number of integers in the calculation
         * given only + and *
         */
        private readonly string[] _input;

        public Day7(string filePath)
        {
            _input = File.ReadAllLines(filePath);
        }

        public void Part1()
        {
            // Read file by line
            // Take answer up to index of ':' as int
            // Take the rest and split into int[]

            var equations = _input.Select(line =>
            {
                var parts = line.Split(':');
                var key = Int64.Parse(parts[0]);
                var numbers = parts[1].Trim().Split(" ")
                    .Select(int.Parse).ToArray();
                return new { Key = key, Numbers = numbers };
            }).ToDictionary(k => k.Key, k => k.Numbers);

            List<Int64> possible = new();
            foreach (var kvp in equations)
            {
                var combinations = GeneratePossibleResults(kvp.Value, 0, kvp.Value.Length);
                
                if (combinations.Contains(kvp.Key)) possible.Add(kvp.Key);
            }
            Console.WriteLine($"Part1 sum of possibel: {possible.Sum()}");
        }

        public void Part2()
        {
            // throw new NotImplementedException();
        }


        private List<Int64> GeneratePossibleResults(int[] numbers, int start, int length)
        {
            // The numbers array contains only 1 number
            if (length - start == 1)
            {
                return new List<Int64> { numbers[start] };
            }

            var combinations = new List<Int64>();
            for (int i = start; i < length - 1; i++)
            {
                var leftCombinations = GeneratePossibleResults(numbers, start, i + 1);
                var rightCombinations = GeneratePossibleResults(numbers, i + 1, length);
                foreach (var left in leftCombinations)
                {
                    foreach (var right in rightCombinations)
                    {
                        combinations.Add(left + right);
                        combinations.Add(left * right);
                    }
                }
            }

            return combinations;
        }
    }
}