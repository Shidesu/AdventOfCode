using System.Text.RegularExpressions;
using AdventOfCodeSupport;

namespace AdventOfCodeDay1._2022;

public class Day05 : AdventBase
{
    protected override void InternalPart1()
    {
        var inputLines = InputText
            .Split('\n', StringSplitOptions.RemoveEmptyEntries).ToArray();

        var pilesLines = inputLines
            .TakeWhile(x => !Regex.IsMatch(x, @" \d+"))
            .ToArray();
        var columns = pilesLines
            .Select(x => x
                .Chunk(4)
                .Select(c => new string(c))
                .ToArray())
            .Reverse()
            .ToArray();


        var columnCount = columns.First().Count();

        var stacks = Enumerable
            .Range(0, columnCount)
            .Select(x => new Stack<string>())
            .ToList();

        columns
            .Aggregate(stacks, (acc, col) => col
                .Select((x, index) => (value: x, index))
                .Aggregate(acc, (acc, x) =>
                {
                    if (!string.IsNullOrWhiteSpace(x.value))
                        acc[x.index].Push(x.value);
                    return acc;
                }));

        var instructions = inputLines
            .SkipWhile(x => !x
                .StartsWith('m'))
            .Select(i => Regex
                .Match(i, @"move (\d+) from (\d+) to (\d+)")
                .Groups
                .Values
                .Skip(1)
                .Select(x => int.Parse(x.Value))
                .ToArray())
            .Select(i => (CrateCount: i[0], From: i[1] - 1, To: i[2] - 1));
           // .Select(i => (CrateCount: i.));

           instructions.Aggregate(stacks, (acc, i) =>
           {
               for (var j = 0; j < i.CrateCount; j++)
               {
                   var crate = acc[i.From].Pop();
                   acc[i.To].Push(crate);
               }
               return acc;
           });
           
        var result = stacks.Select(x => x.First());
        Console.WriteLine(string.Join(string.Empty, result));
    }

    protected override void InternalPart2()
    {
        var inputLines = InputText
            .Split('\n', StringSplitOptions.RemoveEmptyEntries).ToArray();

        var pilesLines = inputLines
            .TakeWhile(x => !Regex.IsMatch(x, @" \d+"))
            .ToArray();
        var columns = pilesLines
            .Select(x => x
                .Chunk(4)
                .Select(c => new string(c))
                .ToArray())
            .Reverse()
            .ToArray();


        var columnCount = columns.First().Count();

        var stacks = Enumerable
            .Range(0, columnCount)
            .Select(x => new Stack<string>())
            .ToList();

        columns
            .Aggregate(stacks, (acc, col) => col
                .Select((x, index) => (value: x, index))
                .Aggregate(acc, (acc, x) =>
                {
                    if (!string.IsNullOrWhiteSpace(x.value))
                        acc[x.index].Push(x.value);
                    return acc;
                }));

        var instructions = inputLines
            .SkipWhile(x => !x
                .StartsWith('m'))
            .Select(i => Regex
                .Match(i, @"move (\d+) from (\d+) to (\d+)")
                .Groups
                .Values
                .Skip(1)
                .Select(x => int.Parse(x.Value))
                .ToArray())
            .Select(i => (CrateCount: i[0], From: i[1] - 1, To: i[2] - 1));
        // .Select(i => (CrateCount: i.));

        instructions.Aggregate(stacks, (acc, i) =>
        {
            var crates = new Stack<string>();
            for (var j = 0; j < i.CrateCount; j++)
            {
              crates.Push(acc[i.From].Pop());
            }

            foreach (var crate in crates)
            {
                acc[i.To].Push(crate);
            }
            return acc;
        });
        var result = stacks.Select(x => x.First());
        Console.WriteLine(string.Join(string.Empty, result));
    }
}