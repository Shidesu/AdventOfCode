using AdventOfCodeSupport;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeDay1._2022;

[MemoryDiagnoser]
public class Day03 : AdventBase
{
    protected override void InternalPart1()
    {
        var result = InputLines
            .Select(x => (x[..(x.Length/2)], x[(x.Length/2)..]))
            .Select(x => x.Item1.Intersect(x.Item2).First())
            .Select(c => char.IsUpper(c) ? c - 38 : c - 96)
            .Sum();
        
        Console.WriteLine(result);
    }

    protected override void InternalPart2()
    {
        var result = InputLines
            .Chunk(3)
            .Select(x => x.Aggregate(x.First().ToCharArray(), (seed, s) => seed.Intersect(s).ToArray()).First())
            .Select(c => char.IsUpper(c) ? c - 38 : c - 96)
            .Sum();
        
        Console.WriteLine(result);
    }
}