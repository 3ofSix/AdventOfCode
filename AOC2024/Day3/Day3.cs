using System.Text.RegularExpressions;

namespace AOC2024.Day3
{
    public class Day3
    {
        private const string PATTERN = @"mul\((\d{1,3}),(\d{1,3})\)";
        private readonly string _input;

        public Day3(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                _input = reader.ReadToEnd();
            }

        }

        public void Part1()
        {
            //Expected answer 162813399
            
            List<int> values = new();

            foreach (Match match in Regex.Matches(_input, PATTERN))
            {
                values.Add(int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));
            }
            Console.WriteLine($"Part1: {values.Sum()}");
        }
        
        public void Part2()
        {
            // Expected answer Part2: 53783319
            
            List<int> values = new();
            const string dodonot = @"mul\((\d{1,3}),(\d{1,3})\)|don't\(\)|do\(\)";
            bool isSkip = false;

            foreach (Match match in Regex.Matches(_input, dodonot))
            {
                if (match.Value is "don't()" or "do()")
                {
                    isSkip = match.Value == "don't()";
                    continue;
                }

                if (!isSkip)
                {
                    values.Add(int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));
                }
            }

            Console.WriteLine($"Part2: {values.Sum()}");
        }
    }
}
