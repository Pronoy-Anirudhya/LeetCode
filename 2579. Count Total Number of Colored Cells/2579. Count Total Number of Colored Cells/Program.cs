Console.WriteLine(new Solution().ColoredCells(69675));
Console.ReadLine();

public class Solution
{
    public long ColoredCells(int n)
    {
        long coloredCellCount = 1;
        long incrementer = 4;

        if (n <= 1)
            return coloredCellCount;

        //This is just a basic math. At each minute after the 1st minute, the total number of ColoredCells would be as follows:
        //Colored Cell Count = Colored Cell Count from Previous Minute + Incrementer (coloredCellCount += incrementer;)
        //The incrementer will then increase by for after every minute (incrementer += 4;)
        for (int i = 2; i <= n; i++)
        {
            coloredCellCount += incrementer;
            incrementer += 4;
        }

        return coloredCellCount;

        //BFS solution: Will result in TLE
        /*Queue<(long row, long column)> bfs = [];
        HashSet<(long, long)> hasAlreadyBeenColored = [];
        (int dx, int dy)[] directions = [(0, -1), (0, 1), (-1, 0), (1, 0)];

        bfs.Enqueue((0, 0));
        hasAlreadyBeenColored.Add((0, 0));

        while (n-- > 0)
        {
            long queueCount = bfs.Count;
            coloredCellCount += queueCount;

            while (queueCount-- > 0)
            {
                var currentCell = bfs.Dequeue();

                foreach (var direction in directions)
                {
                    (long row, long column) = (currentCell.row + direction.dx, currentCell.column + direction.dy);

                    if (hasAlreadyBeenColored.Contains((row, column)))
                        continue;

                    hasAlreadyBeenColored.Add((row, column));
                    bfs.Enqueue((row, column));
                }
            }
        }*/
    }
}