using PlainFiles.Backend;

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
            AddPerson();
            break;

        case "2":
            ShowList();
            break;

        case "3":
            saveFile(people, listName);
            Console.WriteLine("List saved.");
            break;

        case "4":
            DeletePerson();
            break;

        case "5":
            SortData();
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

void AddPerson()
{
    Console.Write("Enter name: ");
    var name = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter lastName: ");
    var lastName = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter age: ");
    var age = Console.ReadLine() ?? string.Empty;
    people.Add(new[] { name, lastName, age });
    Console.WriteLine("Person added.");
}

void ShowList()
{
    Console.WriteLine($"List of {listName}");
    Console.WriteLine(" --------------------------------------------------------");
    Console.WriteLine("|\tName\t|\tLast Name\t|\tAge\t|");
    Console.WriteLine(" --------------------------------------------------------");
    foreach (var person in people)
    {
        Console.WriteLine($"|   {person[0]}\t|\t{person[1]}\t|\t{person[2]}\t|");
        Console.WriteLine(" --------------------------------------------------------");
    }
}

void DeletePerson()
{
    Console.Write("Enter name to delete: ");
    var nameToDelete = Console.ReadLine();
    var peopleToDelete = people
        .Where(p => p[0].Equals(nameToDelete, StringComparison.OrdinalIgnoreCase))
        .ToList();

    if (peopleToDelete.Count == 0)
    {
        Console.WriteLine("No people with that name were found.");
        return;
    }

    for (int i = 0; i < peopleToDelete.Count; i++)
    {
        Console.WriteLine($"ID: {i} - Names: {peopleToDelete[i][0]} {peopleToDelete[i][1]}, age: {peopleToDelete[i][2]}");
    }

    int id;
    do
    {
        Console.Write("Enter the ID of the item you want to delete, or -1 to cancel.? ");
        var idString = Console.ReadLine();
        int.TryParse(idString, out id);
        if (id < -1 || id > peopleToDelete.Count)
        {
            Console.WriteLine("Invalid ID. Please try again.");
        }
    } while (id < -1 || id > peopleToDelete.Count);

    if (id == -1)
    {
        Console.WriteLine("Canceled operation.");
        return;
    }

    var personToRemove = peopleToDelete[id];
    people.Remove(personToRemove);
}

void SortData()
{
    int order;
    do
    {
        Console.Write("Which field do you want to sort by? --> 0. First Name, 1. Last Name, 2. Age? ");
        var orderString = Console.ReadLine();
        int.TryParse(orderString, out order);
        if (order < 0 || order > 2)
        {
            Console.WriteLine("Invalid order. Please try again..");
        }
    } while (order < 0 || order > 2);

    int type;
    do
    {
        Console.Write("How do you want to sort --> 0. Ascending, 1. Descending?? ");
        var typeString = Console.ReadLine();
        int.TryParse(typeString, out type);
        if (type < 0 || type > 1)
        {
            Console.WriteLine("Invalid order. Please try again..");
        }
    } while (type < 0 || type > 1);

    people.Sort((a, b) =>
    {
        int cmp;
        if (order == 2) // Age: Compare as a number
        {
            bool parsedA = int.TryParse(a[2], out var ageA);
            bool parsedB = int.TryParse(b[2], out var ageB);

            //If it cannot be parsed, we treat it as - infinity so that it remains at the beginning
            if (!parsedA) ageA = int.MinValue;
            if (!parsedB) ageB = int.MinValue;

            cmp = ageA.CompareTo(ageB);
        }
        else // First or Last Name: text comparison, ignoring uppercase/lowercase
        {
            cmp = string.Compare(a[order], b[order], StringComparison.OrdinalIgnoreCase);
        }

        return type == 0 ? cmp : -cmp; // 0 = ascending, 1 = descending
    });

    Console.WriteLine("Sorted data.");
}

string Menu()
{
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show list");
    Console.WriteLine("3. Save file");
    Console.WriteLine("4. Delete");
    Console.WriteLine("5. Sort");
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