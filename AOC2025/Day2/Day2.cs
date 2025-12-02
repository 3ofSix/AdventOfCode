using System.Text.RegularExpressions;

namespace AOC2025
{
    public class Day2 : IPuzzleSolver
    {   // Match a pattern
        // Add up the matched pattern

        private readonly List<(long First, long Last)> ranges;
        public Day2(string filePath)
        {
            string line = File.ReadAllText(filePath);
            // split line on commas
             ranges = line
                .Split(',') // Split the string into ranges ["11-22","95-115"]
                .Select(range => range.Split('-')) // Split each range into values ["11", "22"]
                .Select(ids => (First: Int64.Parse(ids[0]), Last: Int64.Parse(ids[1])))
                .ToList();
        }

        public void Part1()
        {
            // Sample expected 1227775554
            // Puzzle Expected answer 34826702005

            var regExPattern = @"^(\d+)\1$";
            var total = GetMatches(regExPattern).Sum();

            Console.WriteLine($"Part 1 Total is {total}");
        }
        public void Part2()
        {
            // Sample expected 4174379265
            // Puzzle expected answer 43287141963
            var regExPattern = @"^(\d+)\1+$";
            var total = GetMatches(regExPattern).Sum();
            
            Console.WriteLine("----");
            Console.WriteLine($"Part 2 Total is {total}");
        }

        private List<long> GetMatches(string pattern)
        {
            List<long> matches = new();

           
            foreach (var (First, Last) in ranges)
            {
                for (var i = First; i <= Last; i++)
                {
                    Match match = Regex.Match(i.ToString(), pattern);
                    if (match.Success)
                    {
                        matches.Add(i);
                    }
                }

            }

            return matches;
        }
    }
}
