using AdventOfCodeSupport;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeDay1._2022;

[MemoryDiagnoser]
[ShortRunJob]
public class Day03 : AdventBase
{
    protected override void InternalPart1()
    {
        var result = InputLines
            .Select(x => x
                .AsSpan()[..(x.Length / 2)]
                .ToArray()
                .Intersect(x
                    .AsSpan()[(x.Length / 2)..]
                    .ToArray())
                .First())
            .Sum(c => char.IsUpper(c) ? c - 38 : c - 96);

        Console.WriteLine(result);
    }

    protected override void InternalPart2()
    {
        var result = InputLines
            .Chunk(3)
            .Select(x => x
                .Aggregate(x
                    .First()
                    .AsEnumerable(), (acc, s) => acc
                    .Intersect(s))
                .First())
            .Sum(c => c is >= 'A' and <= 'Z' ? c - 38 : c - 96);

        Console.WriteLine(result);
    }
}