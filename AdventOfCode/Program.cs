// See https://aka.ms/new-console-template for more information

using AdventOfCodeSupport;

Console.WriteLine("Hello, World!");

var solutions = new AdventSolutions();

await solutions.DownloadInputsAsync();
solutions.GetMostRecentDay().Part1().Part2();
// solutions.Benchmark();