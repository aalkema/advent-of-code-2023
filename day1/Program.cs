namespace day11.console;

public class Program
{
    private static Dictionary<string, char> numbers = new Dictionary<string, char>() {
        { "one", '1' },
        { "two", '2' },
        { "three", '3' },
        { "four", '4' },
        { "five", '5' },
        { "six", '6' },
        { "seven", '7' },
        { "eight", '8' },
        { "nine", '9' },
        { "zero", '0' }
    };

    private static Dictionary<string, char> reverseNumbers = new Dictionary<string, char>() {
        { "eno", '1' },
        { "owt", '2' },
        { "eerht", '3' },
        { "ruof", '4' },
        { "evif", '5' },
        { "xis", '6' },
        { "neves", '7' },
        { "thgie", '8' },
        { "enin", '9' },
        { "orez", '0' }
    };
    private static void Main(string[] args)
    {
        using FileStream fs = File.OpenRead("input.txt");
        using var sr = new StreamReader(fs);

        string line;
        int sum = 0;
        while ((line = sr.ReadLine()) != null) {
            sum += GetFirstAndLastNumbers(line);
        }
        Console.WriteLine(sum);
    }

    private static int GetFirstAndLastDigits(string line) {
        char[] lineChars = line.ToCharArray();
        char firstDig = GetFirstDigitInString(lineChars);
        Array.Reverse(lineChars);
        char secondDig = GetFirstDigitInString(lineChars);
        return Int32.Parse($"{firstDig}{secondDig}");
    }

    private static char GetFirstDigitInString(char[] input) {
        foreach (char c in input) {
            if (char.IsDigit(c)) {
                return c;
            }
        }
        return 'x';
    }

    private static int GetFirstAndLastNumbers(string input) {
        char firstDig = GetFirstNumberInString(input, numbers);
        char[] inputChars = input.ToCharArray();
        Array.Reverse(inputChars);
        string reverseInput = new string(inputChars);
        char secondDig = GetFirstNumberInString(reverseInput, reverseNumbers);
        return Int32.Parse($"{firstDig}{secondDig}");
    }

    private static char GetFirstNumberInString(string input, Dictionary<string, char> dict) {
        for (int i = 0; i < input.Length; i++) {
            if (char.IsDigit(input[i])) {
                return input[i];
            } else {
                string atThisChar = input.Substring(i);
                foreach (string number in dict.Keys) {
                    if (atThisChar.StartsWith(number)) {
                        return dict[number];
                    }
                }
            }
        }
        return 'x';
    }
}