using AdventOfCodeSupport;

namespace AdventOfCodeDay1._2022;
public class Day02 : AdventBase
{
    private readonly Dictionary<(char, char), int> _outcomes = new Dictionary<(char, char), int>
    {
        { ('A', 'Y'), 8 },
        { ('A', 'Z'), 1 },
        { ('B', 'X'), 8 },
        { ('B', 'Y'), 1 },
        { ('C', 'X'), 1 },
        { ('C', 'Z'), 8 }
    };

    protected override void InternalPart1()
    {
        Console.WriteLine(GetTotalScore(r => _outcomes[r]));
    }

    protected override void InternalPart2()
    {
        Console.WriteLine(GetTotalScore(r =>
        {
            var x = r.Item1;
            var y = r.Item2;

            if (y == 'Z')
            {
                return 6 + XToWin(x - 64);
            }
            else if (y == 'Y')
            {
                return 3 + x - 64;
            }
            else if (y == 'X')
            {
                return 0 + XToLose(x - 64);
            }

            return 0;
        }));
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

    private int XToWin(int x) => x switch
    {
        1 => 2,
        2 => 3,
        3 => 1
    };

    private int XToLose(int x) => x switch
    {
        1 => 3,
        2 => 1,
        3 => 2
    };
}
