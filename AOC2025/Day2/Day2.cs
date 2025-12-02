using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2025.Day2
{
    public class Day2
    { // Match a pattern
        // Add up the matched pattern

        private string line;
        public Day2(string filePath)
        {
            line = File.ReadAllText(filePath);
        }

        public void Part1()
        {
            // Expected answer 34826702005
            List<long> theIds = new List<long>();
            var regExPattern = @"^(\d+)\1$";
            // split line on commas
            var ranges = line
                .Split(',') // Split the string into ranges ["11-22","95-115"]
                .Select(range => range.Split('-')) // Split each range into values ["11", "22"]
                .Select(ids => (First: Int64.Parse(ids[0]), Last: Int64.Parse(ids[1])))
                .ToList();

            foreach (var range in ranges)
            {
                //Console.WriteLine($"Range is {range}, first is {range.First}, second is {range.Last}");
                for (var i = range.First; i <= range.Last; i++)
                {
                    Match match = Regex.Match(i.ToString(), regExPattern);
                    if (match.Success)
                    {
                        Console.WriteLine($"Match {i},");
                        theIds.Add(i);
                    }
                }

            }
            Console.WriteLine($"Part 1 Total is {theIds.Sum()}");
        }
        public void Part2()
        {

            // Expected answer 43287141963
            List<long> theIds = new List<long>();
            var regExPattern = @"^(\d+)\1+$";
            // split line on commas
            var ranges = line
                .Split(',') // Split the string into ranges ["11-22","95-115"]
                .Select(range => range.Split('-')) // Split each range into values ["11", "22"]
                .Select(ids => (First: Int64.Parse(ids[0]), Last: Int64.Parse(ids[1])))
                .ToList();

            foreach (var range in ranges)
            {
                //Console.WriteLine($"Range is {range}, first is {range.First}, second is {range.Last}");
                for (var i = range.First; i <= range.Last; i++)
                {
                    Match match = Regex.Match(i.ToString(), regExPattern);
                    if (match.Success)
                    {
                        Console.WriteLine($"Match {i},");
                        theIds.Add(i);
                    }
                }

            }
            Console.WriteLine("----");
            Console.WriteLine($"Part 2 Total is {theIds.Sum()}");
        }
    }
}
