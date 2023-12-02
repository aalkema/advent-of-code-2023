namespace day2.console;

public class Game {
    public Game(string line) {
        Rounds = new List<Dictionary<string, int>>();
        SmallestPossibleSet = new Dictionary<string, int>();
        ParseLine(line);
        Power = 1;
        foreach (string color in SmallestPossibleSet.Keys) {
            Power *= SmallestPossibleSet[color];
        }
    }
    public int Id;
    public List<Dictionary<string, int>> Rounds;
    public Dictionary<string, int> SmallestPossibleSet;
    public int Power;

    public bool IsValid(Dictionary<string, int> totalInBag) {
        foreach (var round in Rounds) {
            foreach (var color in round.Keys) {
                if (round[color] > totalInBag[color]) {
                    return false;
                }
            }
        }
        return true;
    }

    private void ParseLine(string line) {
        string[] parts = line.Split(":");
        this.Id = Int32.Parse(parts[0].Split(" ")[1]);

        string[] rounds = parts[1].Split(";");
        foreach (string round in rounds) {
            string[] cubes = round.Split(",");
            var roundSummary = new Dictionary<string, int>();
            foreach (string cube in cubes) {
                var cleanCube = cube.Trim();
                string[] values = cleanCube.Split(" ");
                roundSummary.Add(values[1], Int32.Parse(values[0]));
                Rounds.Add(roundSummary);
                UpdateSmallestSet(roundSummary);
            }
        }
    }

    private void UpdateSmallestSet(Dictionary<string, int> round) {
        foreach (string color in round.Keys) {
            if (SmallestPossibleSet.ContainsKey(color)) {
                if (round[color] > SmallestPossibleSet[color]) {
                    SmallestPossibleSet[color] = round[color];
                }
            } else {
                SmallestPossibleSet[color] = round[color];
            }
        }
    }
}