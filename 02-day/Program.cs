using System.Collections;
using System.IO;

using Types;

Console.WriteLine("Reading from file...");
string input = File.ReadAllText("input.txt");
Console.WriteLine($"Read {input.Length} characters from file.\n");

var mapper = new ChoiceMapper();

Console.WriteLine("Parsing input...");
var totalPointsPartOne = 0;
var totalPointsPartTwo = 0;

string[] lines = input.Split("\n");

for (var i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    Console.WriteLine($"Parsing line {i + 1}: {line}");
    var choices = line.Split(" ");
    var them = mapper.mapThem(choices[0]);

    // Part 1
    var me = mapper.mapMe(choices[1]);
    var choicePoints = mapper.getSelectionPoints(me);
    var resultPoints = mapper.getResultPoints(them, me);
    // Console.WriteLine($"Them: {them}, Me: {me}, Resulting Points: {resultPoints}");
    totalPointsPartOne += choicePoints + resultPoints;

    // Part 2
    var resultPointsPartTwo = mapper.mapResult(choices[1]);
    var choice = mapper.getChoiceForResult(them, choices[1]);
    var choicePointsPartTwo = mapper.getSelectionPoints(choice);
    totalPointsPartTwo += choicePointsPartTwo + resultPointsPartTwo;
}

Console.WriteLine($"Total Points Part 1: {totalPointsPartOne}");
Console.WriteLine($"Total Points Part 2: {totalPointsPartTwo}");

