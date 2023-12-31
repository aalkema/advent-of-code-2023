﻿namespace day2.console;

public class Program
{
    private static void Main(string[] args)
    {
        var totalInBag = new Dictionary<string, int>() {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };

        using FileStream fs = File.OpenRead("input.txt");
        using var sr = new StreamReader(fs);

        string line;
        int sum = 0;
        int powerSum = 0;
        while ((line = sr.ReadLine()) != null) {
            var game = new Game(line);
            if (game.IsValid(totalInBag)) {
                sum += game.Id;
            }
            powerSum += game.Power;
        }
        Console.WriteLine(sum);
        Console.WriteLine(powerSum);
    }
}