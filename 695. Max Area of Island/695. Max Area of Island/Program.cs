Console.WriteLine(new Solution().MaxAreaOfIsland([[1, 1, 0, 0, 0], [1, 1, 0, 0, 0], [0, 0, 0, 1, 1], [0, 0, 0, 1, 1]]));
Console.ReadLine();

public class Solution
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        int maxAreaOfIsland = 0;
        (int rowLength, int columnLength) = (grid.Length, grid[0].Length);

        for (int row = 0; row < rowLength; row++)
        {
            for (int column = 0; column < columnLength; column++)
            {
                if (grid[row][column] == 1)
                {
                    int area = DFSGetIslandArea(grid, row, column); //BFSGetIslandArea(grid, row, column);
                    maxAreaOfIsland = Math.Max(maxAreaOfIsland, area);
                }
            }
        }

        return maxAreaOfIsland;
    }

    private int BFSGetIslandArea(int[][] grid, int row, int column)
    {
        int islandArea = 0;
        Queue<(int row, int column)> bfs = [];
        (int dx, int dy)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];
        bfs.Enqueue((row, column));

        while (bfs.Count > 0)
        {
            (int currentRow, int currentColumn) = bfs.Dequeue();
            grid[currentRow][currentColumn] = 0; //Instead of using a VISITED BOOLEAN array, to keep it constant space, we are utilizing the Grid values itself. Whenever we have visited a grid, we are gonna make that value 0 so that we know that it's visited and it doesn't get picked again.

            foreach (var direction in directions)
            {
                (int nextRow, int nextColumn) = (currentRow + direction.dx, currentColumn + direction.dy);

                //Out of bound
                if (nextRow < 0 || nextRow >= grid.Length || nextColumn < 0 || nextColumn >= grid[0].Length)
                    continue;

                //Either not part of the island or has already been visited
                if (grid[nextRow][nextColumn] == 0)
                    continue;

                bfs.Enqueue((nextRow, nextColumn));
                grid[nextRow][nextColumn] = 0; // If we don't make it visited, this grid can get enqueued again during the same counting process. So when using BFS, we have to make sure once the grid is enqueued, it needs to be made visited.
            }

            islandArea++;
        }

        return islandArea;
    }

    private int DFSGetIslandArea(int[][] grid, int row, int column)
    {
        //Out of bound
        if (row < 0 || row >= grid.Length || column < 0 || column >= grid[0].Length)
            return 0;

        //Either not part of the island or has already been visited
        if (grid[row][column] == 0)
            return 0;

        int area = 1; //For every depth, we will start from 1 and then add their respective neighbor's values.
        grid[row][column] = 0; //Instead of using a VISITED BOOLEAN array, to keep it constant space, we are utilizing the Grid values itself. Whenever we have visited a grid, we are gonna make that value 0 so that we know that it's visited and it doesn't get picked again.
        (int dx, int dy)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];

        foreach (var direction in directions)
        {
            (int nextRow, int nextColumn) = (row + direction.dx, column + direction.dy);
            area += DFSGetIslandArea(grid, nextRow, nextColumn);
        }
        
        return area;
    }
}