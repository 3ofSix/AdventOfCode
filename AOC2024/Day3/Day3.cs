using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Text.RegularExpressions;

namespace AOC2024.Day3
{
    public class Day3
    {
        private const string PATTERN = @"mul\((\d{1,3}),(\d{1,3})\)";

        public void Part1(string filePath)
        {
            List<int> instructions = new();
            try
            {
                using StreamReader reader = new StreamReader(filePath);
                
                string input = reader.ReadToEnd();

                foreach (Match match in Regex.Matches(input,PATTERN))
                {
                    Console.WriteLine($"Found {match.Value} at {match.Index}: Groups: {match.Groups[1]}, {match.Groups[2]}");
                    instructions.Add(int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));
                }

                Console.WriteLine($"Sum: {instructions.Sum()}");


            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        public void Part2()
        {

        }
    }
}
