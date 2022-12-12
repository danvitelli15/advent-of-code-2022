using System.IO;
using System.Collections.Generic;

Console.WriteLine("Reading from file...");
string input = File.ReadAllText("input.txt");
Console.WriteLine($"Read {input.Length} characters from file.\n");

var moves = input.Split('\n');
Console.WriteLine($"Read {moves.Length} moves from file.\n");

# region Part 1
Console.WriteLine("Part 1");

var headX = 0;
var headY = 0;
var tailX = 0;
var tailY = 0;

var headXMax = 0;
var headYMax = 0;
var headXMin = 0;
var headYMin = 0;

var visited = new HashSet<string>();

visited.Add($"{tailX},{tailY}");

foreach (var move in moves)
{
    // Console.WriteLine(move);
    var direction = move[0];
    var distance = int.Parse(move[2..]);

    for (var i = 0; i < distance; i++)
    {
        switch (direction)
        {
            case 'U':
                headY++;
                if (headY - tailY > 1)
                {
                    tailY++;
                    if (headX - tailX > 0) tailX++;
                    else if (tailX - headX > 0) tailX--;
                    visited.Add($"{tailX},{tailY}");
                }
                break;
            case 'D':
                headY--;
                if (tailY - headY > 1)
                {
                    tailY--;
                    if (headX - tailX > 0) tailX++;
                    else if (tailX - headX > 0) tailX--;
                    visited.Add($"{tailX},{tailY}");
                }
                break;
            case 'R':
                headX++;
                if (headX - tailX > 1)
                {
                    tailX++;
                    if (headY - tailY > 0) tailY++;
                    else if (tailY - headY > 0) tailY--;
                    visited.Add($"{tailX},{tailY}");
                }
                break;
            case 'L':
                headX--;
                if (tailX - headX > 1)
                {
                    tailX--;
                    if (headY - tailY > 0) tailY++;
                    else if (tailY - headY > 0) tailY--;
                    visited.Add($"{tailX},{tailY}");
                }
                break;
        }
    }

    headXMax = Math.Max(headXMax, headX);
    headYMax = Math.Max(headYMax, headY);
    headXMin = Math.Min(headXMin, headX);
    headYMin = Math.Min(headYMin, headY);
}

// Console.WriteLine($"[{string.Join("], [", visited)}]");

Console.WriteLine($"Field Dimensions: [{headXMax + Math.Abs(headYMin) + 1}, {headYMax + Math.Abs(headYMin) + 1}]\n");

Console.WriteLine($"Tail visited {visited.Count} unique locations.");
#endregion

# region Part 2
Console.WriteLine("Part 2");

#endregion