using System.Text;

namespace day3.console;

public class Schematic {
    public char[,] Map;
    HashSet<string> PointsAdjacentToParts;

    public Schematic(int height, int width) {
        Map = new char[height,width];
        PointsAdjacentToParts = new HashSet<string>();
    }

    public void ParseLine(int column, string line) {
        for (int i = 0; i < line.Length; i++) {
            char point = line[i];
            Map[column,i]=point;
            if ( point == '.' ) continue;
            else if ( char.IsDigit(point) ) continue; // Deal with this in the next scan
            else { // point is a part, find all adjacent points
                for (int j = column-1; j <= column+1; j++) {
                    for (int k = i-1; k <= i+1; k++) {
                        PointsAdjacentToParts.Add($"{j},{k}");
                    }
                }
            }
        }
    }

    public int SumPartNumbers() {
        int sum = 0;
        StringBuilder currentNumber = new StringBuilder();
        bool currentlyBuildingNumber = false;
        bool isPartNumber = false;
        for(int i =0; i < Map.GetLength(0); i++) {
            for (int j = 0; j < Map.GetLength(1); j++) {
                char point = Map[i,j];
                if (char.IsDigit(point)) {
                    if (!currentlyBuildingNumber) {
                        currentNumber = new StringBuilder();
                        currentlyBuildingNumber = true;
                    }
                    currentNumber.Append(point);
                    if (PointsAdjacentToParts.Contains($"{i},{j}")) {
                        isPartNumber = true;
                    }
                }
                if (!char.IsDigit(point)) {
                    if (currentlyBuildingNumber) {
                        if (isPartNumber) {
                            sum += Int32.Parse(currentNumber.ToString());
                            Console.WriteLine(currentNumber.ToString());
                        }
                        currentlyBuildingNumber = false;
                        isPartNumber = false;
                    }
                }
            }
        }
        return sum;
    }
}