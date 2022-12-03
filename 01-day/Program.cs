using System.IO;

Console.WriteLine("Reading from file...");
string input = File.ReadAllText("input.txt");
Console.WriteLine($"Read {input.Length} characters from file.\n");

Console.WriteLine("Spliting up elves' inventories...");
string[] elvesFoods = input.Split("\n\n");
Console.WriteLine($"split up {elvesFoods.Length} elves.\n");

Console.WriteLine("Counting the number of calories each elf has...");
List<int> elvesCalorieTotals = new List<int>();
for (int i = 0; i < elvesFoods.Length; i++)
{
    string[] foods = elvesFoods[i].Split("\n");
    int elfCalories = 0;
    foreach (string food in foods)
    {
        elfCalories += int.Parse(food);
    }
    elvesCalorieTotals.Add(elfCalories);
    //Console.WriteLine($"Elf {i} has {elfCalories} calories.");
}

Console.WriteLine();
elvesCalorieTotals.Sort();
elvesCalorieTotals.Reverse();
Console.WriteLine($"Elf with most calories has {elvesCalorieTotals[0]} calories.\n");

int threeMostTotal = elvesCalorieTotals.Take(3).Sum();
Console.WriteLine($"The three elves with the most calories have a total of {threeMostTotal} calories.");
