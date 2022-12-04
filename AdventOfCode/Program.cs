// See https://aka.ms/new-console-template for more information

using System.Runtime;
using AdventOfCodeSupport;

GCSettings.LatencyMode = GCLatencyMode.LowLatency;
GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;

var solutions = new AdventSolutions();

await solutions.DownloadInputsAsync();
solutions.GetMostRecentDay().Part1().Part2();
solutions.GetMostRecentDay().Benchmark();
