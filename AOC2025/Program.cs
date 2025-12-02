// See https://aka.ms/new-console-template for more information

using AOC2025;

var factory = new PuzzleSolverFactory();

while (true)
{
    Console.WriteLine("\n\tAdvent of Code 2025");
    Console.WriteLine("\nWhat day do you want to solve?");
    Console.WriteLine("\nType a number for the day?\n\t(0 for exit)");

    if (!uint.TryParse(Console.ReadLine(), out uint day) || day == 0)
        break;

    
    Console.WriteLine("----------------");
    Console.WriteLine("Attempt solve for sample or puzzle input?");
    Console.WriteLine("\t1 - Sample \n\t2 - Puzzle");
    Console.WriteLine("\t0 - Exit");

    if (!uint.TryParse(Console.ReadLine(), out uint version) || version == 0)
        break;

    PuzzleType puzzleType = version switch
    {
        1 => PuzzleType.Sample,

        2 => PuzzleType.Puzzle,
        _ => throw new ArgumentException("Invalid selection")
    };
    
    string file = puzzleType == PuzzleType.Sample ? $@"../../../Day{day}/sample.txt" : $@"../../../Day{day}/puzzle.txt";
    try
    {
        var solver = factory.CreateSolver(day, file);
        solver.Part1();
        solver.Part2();
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}