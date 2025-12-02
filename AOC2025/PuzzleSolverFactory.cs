using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;


namespace AOC2025
{
    public class PuzzleSolverFactory : IPuzzleSolverFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<uint, Type> _solverTypes;

        public PuzzleSolverFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            // Auto register all solvers of type IPuzzleSolver by scanning Dependency Injection Container
            _solverTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => typeof(IPuzzleSolver).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .Select(t => new {Type = t, Attr = t.GetCustomAttribute<PuzzleDayAttribute>() })
                .Where(x => x.Attr != null) // Filter for classes only with the attribute
                .ToDictionary(x => x.Attr!.Day, x => x.Type);
        }

        public IPuzzleSolver CreateSolver(uint day, string filePath)
        {
            if (_solverTypes.TryGetValue(day, out var solver))
            {
                return (IPuzzleSolver)ActivatorUtilities.CreateInstance(_serviceProvider,solver, filePath);
            }
            throw new ArgumentException($"No solver for day {day}");
        }
    }
}
