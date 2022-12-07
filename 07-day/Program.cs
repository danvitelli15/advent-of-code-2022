using System.IO;

using Types;

Console.WriteLine("Reading from file...");
string input = File.ReadAllText("input.txt");
Console.WriteLine($"Read {input.Length} characters from file.\n");

var changingthefickingnamebecausevscodeiscompletelyfuckingbraindead = input.Split("\n");

var root = new SystemDirectory("/", new SystemDirectory("the ether", null));

SystemDirectory cwd = root;

foreach (var command in changingthefickingnamebecausevscodeiscompletelyfuckingbraindead)
{
    if (command == "$ cd /") cwd = root;
    else if (command.StartsWith("$ cd ..")) cwd = cwd.Parent;
    else if (command.StartsWith("$ cd ")) cwd = cwd.Directories.Find(d => d.Name == command.Substring(5));
    else if (command.StartsWith("dir ")) cwd.Directories.Add(new SystemDirectory(command.Substring(4), cwd));
    else if (command.StartsWith("$")) continue;
    else
    {
        var parts = command.Split(" ");
        cwd.Files.Add(new SystemFile { Name = parts[1], Size = Int32.Parse(parts[0]) });
    }
}

# region Part 1
var dirsUnderSize = new List<SystemDirectory>();

root.GetSize(dirsUnderSize, 100000, Comparison.LessThan);

Console.WriteLine($"Directories under 100,000 bytes: {dirsUnderSize.Sum(dir => dir.Size)}");
# endregion

# region Part 2
var target = 70000000 - root.Size;

var dirsOverSize = new List<SystemDirectory>();

root.GetSize(dirsOverSize, target, Comparison.GreaterThan);

// Console.WriteLine(root.ToString(""));
// dirsOverSize.Where(dir => dir.Size > target).Min();
// Console.WriteLine(string.Join("\n", dirsOverSize.Select(dir => dir.Size).OrderBy(size => size)));
Console.WriteLine($"Smallest Directory over {target} bytes: {dirsOverSize.Min(dir => dir.Size)}");
#endregion