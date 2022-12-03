// See https://aka.ms/new-console-template for more information

using AdventOfCodeSupport;


var solutions = new AdventSolutions();

await solutions.DownloadInputsAsync();
solutions.GetMostRecentDay().Part1().Part2();
solutions.GetMostRecentDay().Benchmark();
// solutions.GetDay(2022, 2).Part1().Part2().Benchmark();
