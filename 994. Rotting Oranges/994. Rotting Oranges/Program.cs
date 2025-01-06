Console.WriteLine(new Solution().OrangesRotting([[0]]));
Console.ReadLine();

public class Solution
{
    public int OrangesRotting(int[][] grid)
    {
        int timeRequired = -1, totalFreshOrange = 0;
        Queue<(int row, int column)> bfs = [];
        (int dx, int dy)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];

        for (int row = 0; row < grid.Length; row++)
        {
            for (int column = 0; column < grid[row].Length; column++)
            {
                if (grid[row][column] == 1)
                    totalFreshOrange++;
                else if (grid[row][column] == 2)
                    bfs.Enqueue((row, column));
            }
        }

        //There's no fresh orange, so no point in continuing.
        if (totalFreshOrange == 0)
            return 0;

        while (bfs.Count > 0)
        {
            int rottentOrangeCount = bfs.Count; //Each minute, all the rotten oranges will make their adjacent fresh oranges rotten. That's why we are getting the current rotten orange count and then iterate and enqueue all the their fresh oranges at once.

            for (int rottenOrange = 0; rottenOrange < rottentOrangeCount; rottenOrange++)
            {
                (int row, int column) = bfs.Dequeue();

                foreach (var direction in directions)
                {
                    (int nextRow, int nextColumn) = (row + direction.dx, column + direction.dy);

                    //Out of bound
                    if (nextRow < 0 || nextRow >= grid.Length || nextColumn < 0 || nextColumn >= grid[0].Length)
                        continue;

                    //Empty cell or Rotten Orange
                    if (grid[nextRow][nextColumn] == 0 || grid[nextRow][nextColumn] == 2)
                        continue;

                    totalFreshOrange--;
                    bfs.Enqueue((nextRow, nextColumn));
                    grid[nextRow][nextColumn] = 0; //Making it emty so that it won't get picked up again by any other rotten oranges in the future
                }
            }

            timeRequired++;
        }

        return totalFreshOrange > 0 ? -1 : timeRequired;
    }
}