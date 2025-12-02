namespace AOC2025
{
    internal interface IPuzzleSolverFactory
    {
        IPuzzleSolver CreateSolver(uint day, string filePath);
    }
}
