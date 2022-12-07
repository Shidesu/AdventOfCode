using AdventOfCodeSupport;

namespace AdventOfCodeDay1._2022;

public class Day06 : AdventBase
{
    protected override void InternalPart1()
    {
        var result = InputText
                .Select((x, i) =>
                    i < InputText.Length - 4
                        ? (span: InputText.AsMemory(i, 4), startingSequence: i + 4)
                        : (span: InputText.AsMemory(i), startingSequence: i + 4))
                .First(x => x.span.Span.ToArray().Distinct().Count() == 4)
            ;

        Console.WriteLine(result.startingSequence);
    }

    protected override void InternalPart2()
    {
        var result = InputText
                .Select((x, i) =>
                    i < InputText.Length - 14
                        ? (span: InputText.AsMemory(i, 14), startingSequence: i + 14)
                        : (span: InputText.AsMemory(i), startingSequence: i + 14))
                .First(x => x.span.Span.ToArray().Distinct().Count() == 14)
            ;

        Console.WriteLine(result.startingSequence);
    }
}