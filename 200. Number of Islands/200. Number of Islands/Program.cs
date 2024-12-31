Console.WriteLine(new Solution().NumIslands([
  ['1','1','0','0','0'],
  ['1','1','0','0','0'],
  ['0','0','1','0','0'],
  ['0','0','0','1','1']
]));
Console.ReadLine();

public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int islands = 0;
        int[,] visited = new int[grid.Length, grid[0].Length];

        for (int row = 0; row < grid.Length; row++)
        {
            for (int column = 0; column < grid[row].Length; column++)
            {
                //We will be doing BFS search every time we encounter a '1'. We will also keep track of the VISITED array so that we don't revisit an already visited Island. And every time we encounter a '1', we will increment the number of Island by 1.
                if (grid[row][column] == '1' && visited[row, column] == 0)
                {
                    visited[row, column] = 1;
                    BFS(grid, row, column, visited);
                    islands++;
                }
            }
        }

        return islands;
    }

    private void BFS(char[][] grid, int row, int column, int[,] visited)
    {
        Queue<(int row, int column)> bfs = [];
        (int dx, int dy)[] directions = [(0, -1), (0, 1), (-1, 0), (1, 0)];
        bfs.Enqueue((row, column));

        while (bfs.Count > 0)
        {
            var currentGrid = bfs.Dequeue();

            foreach (var direction in directions)
            {
                (int nextRow, int nextColumn) = (currentGrid.row + direction.dx, currentGrid.column + direction.dy);

                if (nextRow < 0 || nextRow >= grid.Length || nextColumn < 0 || nextColumn >= grid[0].Length)
                    continue;

                if (grid[nextRow][nextColumn] == '1' && visited[nextRow, nextColumn] == 0)
                {
                    bfs.Enqueue((nextRow, nextColumn));
                    visited[nextRow, nextColumn] = 1;
                }
                    
            }
        }
    }
}