int[,] matrix = { { 1, 0, 0, 1, 0 }, { 1, 0, 1, 0, 0 }, { 0, 0, 1, 0, 1 }, { 1, 0, 1, 0, 1 }, { 1, 0, 1, 1, 0 } };
Console.WriteLine(Solution.RiverSizes(matrix));
Console.ReadLine();

public class Solution
{
    public static List<int> RiverSizes(int[,] matrix)
    {
        var riverSizeList = new List<int>();
        var visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        var adjacentRiverPartQueue = new Queue<Location>();
        var currentRiverSize = 0;

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                currentRiverSize = ProcessRiverPart(adjacentRiverPartQueue, matrix, visited, currentRiverSize, i, j, matrix.GetLength(1), matrix.GetLength(0));
                
                if (currentRiverSize != 0)
                    riverSizeList.Add(currentRiverSize);
            }
        }

        return riverSizeList;
    }

    public static int ProcessRiverPart(Queue<Location> adjacentRiverPartQueue, int[,] matrix, bool[,] visited, int currentRiverSize, int row, int column, int rowLength, int columnLength)
    {
        if (visited[row, column])
            return 0;

        visited[row, column] = true;

        if (matrix[row, column] == 0)
            return 0;

        currentRiverSize++;
        AddAdjacenRiverParts(adjacentRiverPartQueue, row, column, matrix.GetLength(1), matrix.GetLength(0));

        while (adjacentRiverPartQueue.Count > 0)
        {
            var adjacentRiverPart = adjacentRiverPartQueue.Dequeue();
            return ProcessRiverPart(adjacentRiverPartQueue, matrix, visited, currentRiverSize, adjacentRiverPart.Row, adjacentRiverPart.Col, rowLength, columnLength);
            //Console.WriteLine("Row: {0}, Col: {1}, Size: {2}, tempSize: {3}", adjacentRiverPart.Row, adjacentRiverPart.Col, currentRiverSize, riverSize);
        }

        return currentRiverSize;
    }

    public static void AddAdjacenRiverParts(Queue<Location> riverPartQueue, int row, int column, int rowLength, int columnLength)
    {
        var up = row - 1;
        var down = row + 1;
        var left = column - 1;
        var right = column + 1;

        if (up >= 0)
        {
            var location = new Location(up, column);
            riverPartQueue.Enqueue(location);
        }

        if (down <= rowLength)
        {
            var location = new Location(down, column);
            riverPartQueue.Enqueue(location);
        }

        if (left >= 0)
        {
            var location = new Location(row, left);
            riverPartQueue.Enqueue(location);
        }

        if (right <= columnLength)
        {
            var location = new Location(row, right);
            riverPartQueue.Enqueue(location);
        }
    }
}

public class Location
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Location(int row, int col)
    {
        Row = row;
        Col = col;
    }
}