using AdventOfCodeSupport;

namespace AdventOfCodeDay1._2022;

public class Day02 : AdventBase
{
    private readonly Dictionary<(char, char), int> _outcomesPart1 = new()
    {
        {('A', 'X'), 4},
        {('A', 'Y'), 8},
        {('A', 'Z'), 3},
        {('B', 'X'), 1},
        {('B', 'Y'), 5},
        {('B', 'Z'), 9},
        {('C', 'X'), 7},
        {('C', 'Y'), 2},
        {('C', 'Z'), 6},
    };
    
    private readonly Dictionary<(char, char), int> _outcomesPart2 = new()
    {
        {('A', 'X'),3},
        {('A', 'Y'), 4},
        {('A', 'Z'), 8},
        {('B', 'X'), 1},
        {('B', 'Y'), 5},
        {('B', 'Z'), 9},
        {('C', 'X'), 2},
        {('C', 'Y'), 6},
        {('C', 'Z'), 7},
    };

    protected override void InternalPart1()
    {
        Console.WriteLine(GetTotalScore(r => _outcomesPart1[r]));
    }

    protected override void InternalPart2()
    {
        Console.WriteLine(GetTotalScore(r => _outcomesPart2[r]));
    }

    private int GetTotalScore(Func<(char, char), int> outcomeFunc)
    {
        return InputLines
            .Select(l => l.Split(' ').Select(s => s.First()).ToArray())
            .Sum(r =>
            {
                var result = outcomeFunc((r[0], r[1]));
                return result;
            });
    }
}