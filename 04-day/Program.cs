using System.IO;

Console.WriteLine("Reading from file...");
string input = File.ReadAllText("input.txt");
Console.WriteLine($"Read {input.Length} characters from file.\n");

var pairs = input.Split("\n");

var fullyContainedPairs = 0;
var pairsWithOverlap = 0;

foreach (var pair in pairs)
{
    var elves = pair.Split(",");
    var elfOneIndexs = elves[0].Split("-");
    var elfTwoIndexs = elves[1].Split("-");
    var elfOneStart = int.Parse(elfOneIndexs[0]);
    var elfOneEnd = int.Parse(elfOneIndexs[1]);
    var elfTwoStart = int.Parse(elfTwoIndexs[0]);
    var elfTwoEnd = int.Parse(elfTwoIndexs[1]);
    if (
        (elfOneStart <= elfTwoStart && elfOneEnd >= elfTwoEnd) ||
        (elfOneStart >= elfTwoStart && elfOneEnd <= elfTwoEnd)
    )
    {
        fullyContainedPairs++;
    }
    if (
        (elfOneStart >= elfTwoStart && elfOneStart <= elfTwoEnd) ||
        (elfTwoStart >= elfOneStart && elfTwoStart <= elfOneEnd)
    )
    {
        pairsWithOverlap++;
    }
}

Console.WriteLine($"Found {fullyContainedPairs} fully contained pairs.");
Console.WriteLine($"Found {pairsWithOverlap} pairs with overlap.");