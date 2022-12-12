using System.IO;
using System.Collections.Generic;

Console.WriteLine("Reading from file...");
string input = File.ReadAllText("input.txt");
Console.WriteLine($"Read {input.Length} characters from file.\n");

var grid = new List<List<int>>();

foreach (var row in input.Split("\n"))
{
    grid.Add(row.ToCharArray().Select(i => Int32.Parse(i.ToString())).ToList());
}

Console.WriteLine($"Grid: {grid}");

# region Part 1
var visibility = new List<List<bool>>();
for (var i = 0; i < grid.Count; i++)
{
    visibility.Add(new bool[grid[i].Count].ToList());
}

for (int i = 0; i < grid.Count; i++)
{
    for (int j = 0; j < grid[i].Count; j++)
    {
        var current = grid[i][j];
        if (i == 0 || current > grid.Take(i).Select(row => row[j]).Max()) visibility[i][j] = true;
        if (i == grid.Count - 1 || current > grid.TakeLast(grid.Count - i - 1).Select(row => row[j]).Max()) visibility[i][j] = true;
        if (j == 0 || current > grid[i].Take(j).Max()) visibility[i][j] = true;
        if (j == grid.Count - 1 || current > grid[i].TakeLast(grid[i].Count - j - 1).Max()) visibility[i][j] = true;
    }
}

// foreach (var row in visibility)
// {
//     Console.WriteLine(string.Join(" ", row));
// }

var visible = 0;
foreach (var row in visibility)
{
    visible += row.Count(i => i);
}

Console.WriteLine($"visible: {visible}");
#endregion

#region Part 2
var viewScores = new List<List<int>>(grid.Count);

for (var i = 0; i < grid.Count; i++)
{
    viewScores.Add(new int[grid[i].Count].ToList());
}

for (int i = 0; i < grid.Count; i++)
{
    for (int j = 0; j < grid[i].Count; j++)
    {
        var current = grid[i][j];

        var up = grid.Take(i).Select(row => row[j]);
        var down = grid.TakeLast(grid.Count - i - 1).Select(row => row[j]);
        var left = grid[i].Take(j);
        var right = grid[i].TakeLast(grid[i].Count - j - 1);

        var treesUp = up.Count() > 0 ?
                            up.Reverse().ToList().FindIndex(i => i >= current) >= 0 ?
                                up.Reverse().ToList().FindIndex(i => i >= current) + 1 :
                                up.Count() :
                            0;
        var treesDown = down.Count() > 0 ?
                            down.ToList().FindIndex(i => i >= current) >= 0 ?
                                down.ToList().FindIndex(i => i >= current) + 1 :
                                down.Count() :
                            0;
        var treesLeft = left.Count() > 0 ?
                            left.Reverse().ToList().FindIndex(i => i >= current) >= 0 ?
                                left.Reverse().ToList().FindIndex(i => i >= current) + 1 :
                                left.Count() :
                            0;
        var treesRight = right.Count() > 0 ?
                                right.ToList().FindIndex(i => i >= current) >= 0 ?
                                    right.ToList().FindIndex(i => i >= current) + 1 :
                                    right.Count() :
                                0;

        Console.WriteLine($"({i}, {j}): {treesUp} {treesDown} {treesLeft} {treesRight}");

        viewScores[i][j] = treesUp * treesDown * treesLeft * treesRight;
    }
}

foreach (var row in viewScores)
{
    Console.WriteLine(string.Join(" ", row));
}

var max = 0;
foreach (var row in viewScores)
{
    max = Math.Max(max, row.Max());
}
Console.WriteLine($"max: {max}");
#endregion