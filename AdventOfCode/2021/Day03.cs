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
        
    }
}