using System.IO;

#region starting locations
//                 [B] [L]     [J]    
//             [B] [Q] [R]     [D] [T]
//             [G] [H] [H] [M] [N] [F]
//         [J] [N] [D] [F] [J] [H] [B]
//     [Q] [F] [W] [S] [V] [N] [F] [N]
// [W] [N] [H] [M] [L] [B] [R] [T] [Q]
// [L] [T] [C] [R] [R] [J] [W] [Z] [L]
// [S] [J] [S] [T] [T] [M] [D] [B] [H]
//  1   2   3   4   5   6   7   8   9 

var crates = new List<List<char>>() {
    new List<char>() { 'S', 'L', 'W' },
    new List<char>() {'J', 'T', 'N', 'Q'},
    new List<char>() {'S', 'C', 'H', 'F', 'J'},
    new List<char>() {'T', 'R', 'M', 'W', 'N', 'G', 'B'},
    new List<char>() {'T', 'R', 'L', 'S', 'D', 'H', 'Q', 'B'},
    new List<char>() {'M', 'J', 'B', 'V', 'F', 'H', 'R', 'L'},
    new List<char>() {'D', 'W', 'R', 'N', 'J', 'M'},
    new List<char>() {'B', 'Z', 'T', 'F', 'H', 'N', 'D', 'J'},
    new List<char>() {'H', 'L', 'Q', 'N', 'B', 'F', 'T'}
};
#endregion

Console.WriteLine("Reading from file...");
string input = File.ReadAllText("input.txt");
Console.WriteLine($"Read {input.Length} characters from file.\n");

var moves = input.Split("\n");

foreach (var move in moves)
{
    var parts = move.Split(" ");

    var quantity = Int16.Parse(parts[1]);
    var source = Int16.Parse(parts[3]) - 1;
    var destination = Int16.Parse(parts[5]) - 1;

    // Part 1
    // for (int i = 0; i < quantity; i++)
    // {
    //     var crate = crates[source].Last();
    //     crates[source].RemoveAt(crates[source].Count - 1);
    //     crates[destination].Add(crate);
    // }

    // Part 2
    var cratesToMove = crates[source].TakeLast(quantity).ToList();
    crates[source].RemoveRange(crates[source].Count - quantity, quantity);
    crates[destination].AddRange(cratesToMove);
}

var result = "";
foreach (var stack in crates)
{
    result += stack.Last();
}

Console.WriteLine($"Result: {result}");