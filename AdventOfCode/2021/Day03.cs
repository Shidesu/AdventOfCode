using AdventOfCodeSupport;

namespace AdventOfCodeDay1._2021;

public class Day03 : AdventBase
{
    protected override void InternalPart1()
    {
        var bitArrays = InputText.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToArray()).ToArray();
        
        var size = bitArrays.Length;

        var result = new int[12];

        foreach (var bitArray in bitArrays)
        {
            foreach (var (bit, i) in bitArray.Select((c, i) => (c - 48, i)))
            {
                result[i] += bit;
            }
        }

        var gamma = Convert.ToInt32(new string(result.Select(x => x >= size / 2f ? '1' : '0').ToArray()),2);
        var epsilon = Convert.ToInt32(new string(result.Select(x => x >= size / 2f ? '0' : '1').ToArray()),2);
        
        Console.WriteLine(gamma * epsilon);
    }

    protected override void InternalPart2()
    {
        var o2Candidates = InputLines.ToList();
        var co2Candidates = InputLines.ToList();

        var length = InputLines.Length;

        void Iterate(List<string> list, int index, bool invert)
        {
            if (list.Count < 2)
                return;

            var t = list
                .Select(l => l[index])
                .GroupBy(x => x);
            
             var mostCommon   = t
                .MaxBy(x => x.Count()+ x.Key - '0')!
                .Key;

            list.RemoveAll(l => (l[index] != mostCommon) ^ invert);
        }

        for (var i = 0; i < length; i++)
        {
            if (o2Candidates.Count < 2 && co2Candidates.Count < 2)
                break;

            Iterate(o2Candidates, i, false);
            Iterate(co2Candidates, i, true);
        }

        var o2value = Convert.ToInt64(o2Candidates.Single(), 2);
        var co2value = Convert.ToInt64(co2Candidates.Single(), 2);

        Console.WriteLine(o2value * co2value);

    }
}