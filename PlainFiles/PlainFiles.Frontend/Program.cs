using PlainFiles.Backend;
using System.ComponentModel.Design;

var textFile = new SimpleTextFile(".//data//data.txt");
var lines = textFile.ReadAllLines().ToList();
var opt = string.Empty;

do
{
    opt = Menu();
    switch (opt)
    {
        case "1":
            Console.WriteLine("Showing file content:");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            break;

        case "2":
            Console.Write("Enter a new line to add: ");
            var newLine = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(newLine))
            {
                Console.WriteLine("Line cannot be empty. Please try again.");
                break;
            }
            lines.Add(newLine);
            Console.WriteLine("Line added.");
            break;

        case "3":
            textFile.WriteAllLines(lines.ToArray());
            Console.WriteLine("File saved.");
            break;

        case "0":
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
while (opt != "0");
textFile.WriteAllLines(lines.ToArray());
Console.WriteLine("File saved.");

string Menu()
{
    Console.WriteLine("1. Show");
    Console.WriteLine("2. Add");
    Console.WriteLine("3. Save");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    return Console.ReadLine() ?? string.Empty;
}

//////////////////////////////////////////////////////
// EXAMPLE RANDOM NUMBERS WITH CLASS SIMPLETEXTFILE //
//////////////////////////////////////////////////////

//var textFile = new SimpleTextFile("data.txt");
//var random = new Random();
//var lines = new List<string>();
//for (int i = 0; i < 1000; i++)
//{
//    var number = random.Next(1, 1000000);
//    lines.Add($"Random number: {number:N0}");
//}
//textFile.WriteAllLines(lines.ToArray());

//var linesReaded = textFile.ReadAllLines();
//foreach (var line in linesReaded)
//{
//    Console.WriteLine(line);
//}