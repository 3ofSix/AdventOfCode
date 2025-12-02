using System.Reflection;

namespace AOC2025
{
    public class PuzzleSolverFactory : IPuzzleSolverFactory
    {
        private readonly Dictionary<uint, Type> _solverTypes;

        public PuzzleSolverFactory()
        {
            _solverTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(IPuzzleSolver).IsAssignableFrom(type) &&
                type.Name.StartsWith("Day"))
                .ToDictionary(
                type => uint.Parse(type.Name.Substring(3, type.Name.IndexOf("Solver") - 3)),
                type => type);
        }

        public IPuzzleSolver CreateSolver(uint day, string filePath)
        {
            if (_solverTypes.TryGetValue(day, out var solver))
            {
                return (IPuzzleSolver)Activator.CreateInstance(solver, filePath)!;
            }
            throw new ArgumentException($"No solver for day {day}");
        }
    }
}
