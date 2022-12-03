using System.Diagnostics.CodeAnalysis;
using AdventOfCodeSupport;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeDay1._2022;

[MemoryDiagnoser]
public class Day01 : AdventBase
{
    public Day01() : base(2022, 01)
    {
    }

    private IEnumerable<long>? _snacks;

    protected override void InternalPart1()
    {
        LoadSnacks();
        Console.WriteLine(_snacks.First());
    }

    protected override void InternalPart2()
    {
        if (_snacks is null) LoadSnacks();

        Console.WriteLine(_snacks.Take(3).Sum());
    }

    [MemberNotNull(nameof(_snacks))]
    private void LoadSnacks()
    {
        _snacks = InputText.Split("\n\n")
            .Select(inv => inv.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            .Select(inv => inv.Select(long.Parse).Sum())
            .OrderByDescending(x => x);

        // _snacks =
        //     from cal in
        //         from inv in
        //             from line in InputText.Split("\n\n")
        //             select line.Split('\n', StringSplitOptions.RemoveEmptyEntries)
        //         select (from calStr in inv
        //             select long.Parse(calStr))
        //         into calories
        //         select calories.Sum()
        //     orderby cal descending
        //     select cal;

        _snacks =
            from line in InputText.Split("\n\n")
            select line.Split('\n', StringSplitOptions.RemoveEmptyEntries)
            into inventories
            from cal in inventories
            select long.Parse(cal)
            into calories
            select calories;
    }
}