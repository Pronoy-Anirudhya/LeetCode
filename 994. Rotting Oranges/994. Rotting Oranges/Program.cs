Console.WriteLine(new Solution().OrangesRotting([[0]]));
Console.ReadLine();

public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        int requiredMinutesToRotAllOranges = -1, totlaRows = grid.Length, totalColumns = grid[0].Length, totalFreshOranges = 0;
        var bfsQueue = new Queue<(int rottenOrangeRow, int rottenOrangeColumn)>();

        for (int row = 0; row < totlaRows; row++)
        {
            for (int column = 0; column < totalColumns; column++)
            {
                if (grid[row][column] == 1)
                    totalFreshOranges++;

                if (grid[row][column] == 2)
                    bfsQueue.Enqueue((row, column));
            }
        }

        //There are no fresh oranges in the grid, so the required time is 0. No need to go further.
        if (totalFreshOranges == 0)
            return 0;

        while (bfsQueue.Count != 0)
        {
            requiredMinutesToRotAllOranges++;
            int currentNumberOfRottenOranges = bfsQueue.Count;

            for (int rottenOrange = 0; rottenOrange < currentNumberOfRottenOranges; rottenOrange++)
            {
                var (rottenOrangeRow, rottenOrangeColumn) = bfsQueue.Dequeue();

                //Left
                if (rottenOrangeColumn - 1 >= 0 && grid[rottenOrangeRow][rottenOrangeColumn - 1] == 1)
                {
                    grid[rottenOrangeRow][rottenOrangeColumn - 1] = 2;
                    bfsQueue.Enqueue((rottenOrangeRow, rottenOrangeColumn - 1));
                    totalFreshOranges--;
                }

                //Right
                if (rottenOrangeColumn + 1 < totalColumns && grid[rottenOrangeRow][rottenOrangeColumn + 1] == 1)
                {
                    grid[rottenOrangeRow][rottenOrangeColumn + 1] = 2;
                    bfsQueue.Enqueue((rottenOrangeRow, rottenOrangeColumn + 1));
                    totalFreshOranges--;
                }

                //Up
                if (rottenOrangeRow - 1 >= 0 && grid[rottenOrangeRow - 1][rottenOrangeColumn] == 1)
                {
                    grid[rottenOrangeRow - 1][rottenOrangeColumn] = 2;
                    bfsQueue.Enqueue((rottenOrangeRow - 1, rottenOrangeColumn));
                    totalFreshOranges--;
                }

                //Bottom
                if (rottenOrangeRow + 1 < totlaRows && grid[rottenOrangeRow + 1][rottenOrangeColumn] == 1)
                {
                    grid[rottenOrangeRow + 1][rottenOrangeColumn] = 2;
                    bfsQueue.Enqueue((rottenOrangeRow + 1, rottenOrangeColumn));
                    totalFreshOranges--;
                }
            }
        }

        return totalFreshOranges == 0 ? requiredMinutesToRotAllOranges : -1;
    }
}