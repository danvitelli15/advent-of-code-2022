using System.IO;

var priorityLookup = new Dictionary<string, int>
{
    { "a", 1 },
    { "b", 2 },
    { "c", 3 },
    { "d", 4 },
    { "e", 5 },
    { "f", 6 },
    { "g", 7 },
    { "h", 8 },
    { "i", 9 },
    { "j", 10 },
    { "k", 11 },
    { "l", 12 },
    { "m", 13 },
    { "n", 14 },
    { "o", 15 },
    { "p", 16 },
    { "q", 17 },
    { "r", 18 },
    { "s", 19 },
    { "t", 20 },
    { "u", 21 },
    { "v", 22 },
    { "w", 23 },
    { "x", 24 },
    { "y", 25 },
    { "z", 26 },
    { "A", 27 },
    { "B", 28 },
    { "C", 29 },
    { "D", 30 },
    { "E", 31 },
    { "F", 32 },
    { "G", 33 },
    { "H", 34 },
    { "I", 35 },
    { "J", 36 },
    { "K", 37 },
    { "L", 38 },
    { "M", 39 },
    { "N", 40 },
    { "O", 41 },
    { "P", 42 },
    { "Q", 43 },
    { "R", 44 },
    { "S", 45 },
    { "T", 46 },
    { "U", 47 },
    { "V", 48 },
    { "W", 49 },
    { "X", 50 },
    { "Y", 51 },
    { "Z", 52 },
};

Console.WriteLine("Reading from file...");
string input = File.ReadAllText("input.txt");
Console.WriteLine($"Read {input.Length} characters from file.\n");

string[] lines = input.Split("\n");

var total = 0;

foreach (var line in lines)
{
    var half = line.Substring(0, line.Length / 2);

    // Console.WriteLine($"Line: {line}");
    // Console.WriteLine($"Half: {half}");
    // Console.WriteLine($"Half: {line.Substring(line.Length / 2)}");

    foreach (var character in line.Substring(line.Length / 2))
    {
        if (half.Contains(character))
        {
            // Console.WriteLine($"Found {character} is shared");
            // Console.WriteLine($"Priority: {priorityLookup[character.ToString()]}");
            total += priorityLookup[character.ToString()];
            break;
        }
    }
    // Console.WriteLine();
}

Console.WriteLine($"Total: {total}");


var linesList = lines.ToList();

var groupTotal = 0;

for (var offset = 0; offset < linesList.Count; offset += 3)
{
    var group = linesList.Skip(offset).Take(3).ToList();

    foreach (var character in group[0])
    {
        if (group[1].Contains(character) && group[2].Contains(character))
        {
            groupTotal += priorityLookup[character.ToString()];
            break;
        }
    }
}

Console.WriteLine($"Group Total: {groupTotal}");