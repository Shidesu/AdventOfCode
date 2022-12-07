using System.Collections.Specialized;
using System.Text.RegularExpressions;
using AdventOfCodeSupport;
using SuperLinq;

namespace AdventOfCodeDay1._2022;

public class Day07 : AdventBase
{
    protected override void InternalPart1()
    {
        var dirs = new List<Directory>();

        var root = new Directory();

        dirs.Add(root);
        
        
        
        InputLines
            .Aggregate(root, (acc, s) =>
            {
                if (s == "$ cd /")
                    return root;
                if (s.StartsWith("dir"))
                {
                    var dir = new Directory {Parent = acc};
                    dirs.Add(dir);
                    acc.Contents.Add(s.Split(' ').Last(), dir);
                    return acc;
                }
                if (Regex.IsMatch(s, @"\$ cd \w"))
                {
                    return (acc.Contents[s.Split(' ').Last()] as Directory)!;
                }

                if (Regex.IsMatch(s, @"\d+\d+"))
                {
                    var splitted = s.Split(' ');
                    var weight = int.Parse(splitted[0]);
                    acc.Contents.Add(splitted[1], new File(){Bytes = weight, Parent = acc});
                    AddWeight(weight, acc);
                    return acc;
                }

                if (s == "$ cd ..")
                {
                    return acc.Parent;
                }

                return acc;
            });



        var result = dirs.Where(x => x.Bytes < 100000).Sum(x => x.Bytes);
        
        Console.WriteLine(result);
    }

    public void AddWeight(int weight, File dir )
    {
        if(dir.Parent is not null)
            AddWeight(weight, dir.Parent);
        dir.Bytes += weight;
    }
    
    protected override void InternalPart2()
    {
        var dirs = new List<Directory>();

        var root = new Directory();

        dirs.Add(root);
        
        
        
        InputLines
            .Aggregate(root, (acc, s) =>
            {
                if (s == "$ cd /")
                    return root;
                if (s.StartsWith("dir"))
                {
                    var dir = new Directory {Parent = acc};
                    dirs.Add(dir);
                    acc.Contents.Add(s.Split(' ').Last(), dir);
                    return acc;
                }
                if (Regex.IsMatch(s, @"\$ cd \w"))
                {
                    return (acc.Contents[s.Split(' ').Last()] as Directory)!;
                }

                if (Regex.IsMatch(s, @"\d+\d+"))
                {
                    var splitted = s.Split(' ');
                    var weight = int.Parse(splitted[0]);
                    acc.Contents.Add(splitted[1], new File(){Bytes = weight, Parent = acc});
                    AddWeight(weight, acc);
                    return acc;
                }

                if (s == "$ cd ..")
                {
                    return acc.Parent;
                }

                return acc;
            });


        var freeSpace = 70000000 - root.Bytes;
        
        var result = dirs.Where(x => freeSpace + x.Bytes >= 30000000).Min(x => x.Bytes);
        
        Console.WriteLine(result);
    }
}
public class File
{
    public Directory? Parent { get; init; } = null!;
    public long Bytes { get; set; }
}

public class Directory : File
{
    public Dictionary<string, File> Contents { get; } = new();
}