using System.IO;

Console.WriteLine("Reading from file...");
string input = File.ReadAllText("input.txt");
Console.WriteLine($"Read {input.Length} characters from file.\n");

var signal = new List<char>();

for (var i = 0; i < input.Length; i++)
{
    signal.Add(input[i]);
    // Console.WriteLine(string.Join("", signal));
    if (signal.Count == 14)
    {
        if (signal.Distinct().Count() == 14)
        {
            Console.WriteLine($"Found start signal ending at character {i + 1}.");
            break;
        }
        signal.RemoveAt(0);
    }
}