using PlainFiles.Backend;
using System.ComponentModel.Design;

Console.Write("Enter the list name: ");
var listName = Console.ReadLine();
var manualCsv = new ManualCsvHelper();
var people = manualCsv.ReadCsv($"{listName}.csv");
var opt = string.Empty;

do
{
    opt = Menu();
    switch (opt)
    {
        case "1":
            Console.Write("Enter name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter lastName: ");
            var lastName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter age: ");
            var age = Console.ReadLine() ?? string.Empty;
            people.Add(new[] { name, lastName, age });
            Console.WriteLine("Person added.");
            break;

        case "2":
            Console.WriteLine($"List of {listName}");
            Console.WriteLine("Showing list of people: ");
            Console.WriteLine(" --------------------------------------------------------");
            Console.WriteLine("|\tName\t|\tLast Name\t|\tAge\t|");
            Console.WriteLine(" --------------------------------------------------------");
            foreach (var person in people)
            {
                Console.WriteLine($"|   {person[0]}\t|\t{person[1]}\t|\t{person[2]}\t|");
                Console.WriteLine(" --------------------------------------------------------");
            }
            break;

        case "3":
            saveFile(people, listName);
            Console.WriteLine("List saved.");
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
saveFile(people, listName);

string Menu()
{
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show");
    Console.WriteLine("3. Save");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    return Console.ReadLine() ?? string.Empty;
}

void saveFile(List<string[]> people, string? listName)
{
    manualCsv.WriteCsv($"{listName}.csv", people);
}

//////////////////////////////////////////////////////
////// CLASS LOGWRITER EXAMPLE WITH USER INPULT //////
//////////////////////////////////////////////////////

//var textFile = new SimpleTextFile(".\\Data\\data.txt");
//var lines = textFile.ReadAllLines().ToList();
//var opt = string.Empty;

//using var logger = new LogWriter(".\\app.log");
//logger.WriteLog("INFO", "Application started");

//do
//{
//    opt = Menu();
//    switch (opt)
//    {
//        case "1":
//            Console.WriteLine("Showing file content: ");
//            logger.WriteLog("INFO", "The contents of the file were displayed");
//            foreach (var line in lines)
//            {
//                Console.WriteLine(line);
//            }
//            break;

//        case "2":
//            Console.Write("Enter a new line to add: ");
//            var newLine = Console.ReadLine() ?? string.Empty;
//            if (string.IsNullOrWhiteSpace(newLine))
//            {
//                Console.WriteLine("Line cannot be empty. Please try again");
//                logger.WriteLog("WARNING", "Nothing was added");
//                break;
//            }
//            lines.Add(newLine);
//            Console.WriteLine("Line added");
//            logger.WriteLog("INFO", $"Added: {newLine}");
//            break;

//        case "3":
//            textFile.WriteAllLines(lines.ToArray());
//            Console.WriteLine("File saved");
//            logger.WriteLog("INFO", "The file was saved");
//            break;

//        case "0":
//            Console.WriteLine("Exiting...");
//            logger.WriteLog("INFO", "Application finished");
//            break;

//        default:
//            Console.WriteLine("Invalid option. Please try again");
//            logger.WriteLog("ERROR", "An invalid option was selected");
//            break;
//    }
//}
//while (opt != "0");
//textFile.WriteAllLines(lines.ToArray());
//Console.WriteLine("File saved");
//logger.WriteLog("INFO", "The file was saved");

//string Menu()
//{
//    Console.WriteLine("1. Show");
//    Console.WriteLine("2. Add");
//    Console.WriteLine("3. Save");
//    Console.WriteLine("0. Exit");
//    Console.Write("Choose an option: ");
//    return Console.ReadLine() ?? string.Empty;
//}

//////////////////////////////////////////////////////
/// CLASS SIMPLETEXTFIEL EXAMPLE WITH USER INPUT /////
//////////////////////////////////////////////////////

//var textFile = new SimpleTextFile(".//data//data.txt");
//var lines = textFile.ReadAllLines().ToList();
//var opt = string.Empty;

//do
//{
//    opt = Menu();
//    switch (opt)
//    {
//        case "1":
//            Console.WriteLine("Showing file content:");
//            foreach (var line in lines)
//            {
//                Console.WriteLine(line);
//            }
//            break;

//        case "2":
//            Console.Write("Enter a new line to add: ");
//            var newLine = Console.ReadLine() ?? string.Empty;
//            if (string.IsNullOrWhiteSpace(newLine))
//            {
//                Console.WriteLine("Line cannot be empty. Please try again.");
//                break;
//            }
//            lines.Add(newLine);
//            Console.WriteLine("Line added.");
//            break;

//        case "3":
//            textFile.WriteAllLines(lines.ToArray());
//            Console.WriteLine("File saved.");
//            break;

//        case "0":
//            Console.WriteLine("Exiting...");
//            break;

//        default:
//            Console.WriteLine("Invalid option. Please try again.");
//            break;
//    }
//}
//while (opt != "0");
//textFile.WriteAllLines(lines.ToArray());
//Console.WriteLine("File saved.");

//string Menu()
//{
//    Console.WriteLine("1. Show");
//    Console.WriteLine("2. Add");
//    Console.WriteLine("3. Save");
//    Console.WriteLine("0. Exit");
//    Console.Write("Choose an option: ");
//    return Console.ReadLine() ?? string.Empty;
//

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