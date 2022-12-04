using AdventOfCodeSupport;

namespace AdventOfCodeDay1._2022;

public class Day04 : AdventBase
{
    protected override void InternalPart1()
    {
        var result = InputLines
            .Select(line => line
                .Split(',')
                .Select(pair => pair
                    .Split('-')
                    .Select(int.Parse)
                    .ToArray())
                .ToArray())
            .Count(pairs => pairs switch
            {
                [[var x, var u], [var y, var v]] when x >= y && u <= v => true,
                [[var x, var u], [var y, var v]] when y >= x && v <= u => true,
                _ => false
            });
        Console.WriteLine(result);
    }

    protected override void InternalPart2()
    {
        var result = InputLines
            .Select(line => line
                .Split(',')
                .Select(pair => pair
                    .Split('-')
                    .Select(int.Parse)
                    .ToArray())
                .ToArray())
            .Count(pairs => pairs switch
            {
                [[var x, var u], [var y, _]] when x < y && u < y => false,
                [[var x, _], [var y, var v]] when y < x && v < x => false,
                [[var x, _], [_, var v]] when x > v => false,
                [[ _, var u], [var y, _]] when y > u => false,
                _ => true
            });
        Console.WriteLine(result);
    }
}