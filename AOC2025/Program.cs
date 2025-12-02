using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AOC2025;

var services = new ServiceCollection();
// Add logging just because
services.AddLogging(logger =>  logger.AddConsole());
// Register factory
services.AddSingleton<IPuzzleSolverFactory, PuzzleSolverFactory>();

// Register all solvers 

var solverTypes = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(a => a.GetTypes())
    .Where(t => typeof(IPuzzleSolver).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

foreach (var type in solverTypes)
{
    services.AddTransient(type);
}

services.AddTransient<PuzzleMenu>();
var provider = services.BuildServiceProvider();
var menu = provider.GetRequiredService<PuzzleMenu>();
menu.Show();
