// See https://aka.ms/new-console-template for more information

using AOC2024.Day1;
using AOC2024.Day2;

//string p = @"../../../Day2/sample.txt";
// string p = @"../../../Day2/puzzle.txt";
// Day2 day2 = new Day2(p);

Test.Run();

//string p = @"C:\Users\admin\RiderProjects\AdventOfCode\AOC2024\Day1\sample.txt";
string p = @"../../../Day1/puzzle.txt";
var d = new Day1(p);
d.PopulateLists();
//
// int[] list1 = [1, 2, 3, 4, 2, 4, 6, 6,3,5,5,5,5,5,];
// int[] list2 = [4, 6,7,4];
//
// var numbers = list1.GroupBy(n => n);
// var many = list1.GroupBy(num => num) .ToDictionary(g => g.Key, g => g.Sum(num => list2.Count(x => x == num)));
// foreach (var num in many)
// {
//     Console.WriteLine($"Number: {num.Key} occurs {num.Value}");
// }
// var countem = list1.ToLookup(num => num, num =>
// {
//     return list2.Count(x => x == num) * num;
// });
// Console.WriteLine($"Count: {countem.Count()}");
// countem.Select(group => group.Key).ToList().ForEach(num => Console.WriteLine($"Number: {num}:"));
// foreach (var num in countem)
// {
//     Console.WriteLine($"number: {num.Key} occurs {num.Count()}");
// }
// foreach (var number in numbers)
// {
//     Console.WriteLine($"key {number.Key}, value {number.Count()}");
// }
