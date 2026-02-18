using PlainFiles.Backend;

var textFile = new SimpleTextFile("data.txt");
var random = new Random();
var lines = new List<string>();
for (int i = 0; i < 1000; i++)
{
    var number = random.Next(1, 1000000);
    lines.Add($"Random number: {number:N0}");
}
textFile.WriteAllLines(lines.ToArray());

var linesReaded = textFile.ReadAllLines();
foreach (var line in linesReaded)
{
    Console.WriteLine(line);
}