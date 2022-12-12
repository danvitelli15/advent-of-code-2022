using System.IO;
using System.Collections.Generic;

using Types;

Console.WriteLine("Reading from file...");
string input = File.ReadAllText("input.txt");
Console.WriteLine($"Read {input.Length} characters from file.\n");

var moves = input.Split('\n');
Console.WriteLine($"Read {moves.Length} moves from file.\n");

# region Part 1
Console.WriteLine("Part 1");

var rope = new Rope(2);

foreach (var move in moves)
{
    // Console.WriteLine(move);
    var direction = move[0];
    var distance = int.Parse(move[2..]);

    switch (direction)
    {
        case 'U':
            rope.Move(Direction.Up, distance);
            break;
        case 'D':
            rope.Move(Direction.Down, distance);
            break;
        case 'R':
            rope.Move(Direction.Right, distance);
            break;
        case 'L':
            rope.Move(Direction.Left, distance);
            break;
        default:
            throw new System.Exception($"Invalid direction: {direction}");
    }
}

// Console.WriteLine($"[{string.Join("], [", visited)}]");

Console.WriteLine($"Tail visited {rope.Tail.visited.Count} unique locations.");
#endregion

# region Part 2
Console.WriteLine("Part 2");

var ropeDuece = new Rope(10);

foreach (var move in moves)
{
    // Console.WriteLine(move);
    var direction = move[0];
    var distance = int.Parse(move[2..]);

    switch (direction)
    {
        case 'U':
            ropeDuece.Move(Direction.Up, distance);
            break;
        case 'D':
            ropeDuece.Move(Direction.Down, distance);
            break;
        case 'R':
            ropeDuece.Move(Direction.Right, distance);
            break;
        case 'L':
            ropeDuece.Move(Direction.Left, distance);
            break;
        default:
            throw new System.Exception($"Invalid direction: {direction}");
    }
}

Console.WriteLine($"Tail visited {ropeDuece.Tail.visited.Count} unique locations.");

#endregion