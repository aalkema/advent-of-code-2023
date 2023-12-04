namespace day3.console;

public class Program
{
    private static void Main(string[] args)
    {
        string fileName = "input.txt";
        //Readlines lazy loads, so this doesn't look as bad as it seems
        var schematicHeight = File.ReadLines(fileName).Count();
        var schematicWidth = File.ReadLines(fileName).First().Count();
        var schematic = new Schematic(schematicHeight, schematicWidth);

        using FileStream fs = File.OpenRead(fileName);
        using var sr = new StreamReader(fs);

        string line;
        int currentRow = 0;
        int sum = 0;
        while ((line = sr.ReadLine()) != null) {
            schematic.ParseLine(currentRow, line);
            currentRow++;
        }
        Console.WriteLine(schematic.SumPartNumbers());
    }
}