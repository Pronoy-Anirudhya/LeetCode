Console.WriteLine(new Solution().FindMaxFish([[8, 6], [2, 6]]));
Console.ReadLine();

public class Solution
{
    public int FindMaxFish(int[][] grid)
    {
        int maxFish = int.MinValue;
        bool[,] visited = new bool[grid.Length, grid[0].Length];

        for (int row = 0; row < grid.Length; row++)
        {
            for (int column = 0; column < grid[row].Length; column++)
            {
                //Land, so can't start from here
                if (grid[row][column] == 0)
                    continue;

                //Part of the visited grids
                if (visited[row, column])
                    continue;

                visited[row, column] = true;
                maxFish = Math.Max(maxFish, BFS(grid, visited, row, column));
            }
        }

        return maxFish == int.MinValue ? 0 : maxFish;
    }

    private int BFS(int[][] grid, bool[,] visited, int row, int column)
    {
        int fishCaught = 0;
        Queue<(int, int)> bfs = [];
        (int dx, int dy)[] directions = [(0, 1), (0, -1), (-1, 0), (1, 0)];
        bfs.Enqueue((row, column));

        while (bfs.Count > 0)
        {
            (int currentRow, int currentColumn) = bfs.Dequeue();
            fishCaught += grid[currentRow][currentColumn];

            for (int index = 0; index < directions.Length; index++)
            {
                (int nextRow, int nextColumn) = (currentRow + directions[index].dx, currentColumn + directions[index].dy);

                //Out of bound
                if (nextRow < 0 || nextRow >= grid.Length || nextColumn < 0 || nextColumn >= grid[0].Length)
                    continue;

                //Land or already visited
                if (grid[nextRow][nextColumn] == 0 || visited[nextRow, nextColumn])
                    continue;

                bfs.Enqueue((nextRow, nextColumn));
                visited[nextRow, nextColumn] = true;
            }
        }

        return fishCaught;
    }
}