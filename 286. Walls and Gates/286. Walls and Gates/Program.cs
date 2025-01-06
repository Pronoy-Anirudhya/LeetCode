new Solution().islandsAndTreasure([
  [2147483647,-1,0,2147483647],
  [2147483647,2147483647,2147483647,-1],
  [2147483647,-1,2147483647,-1],
  [0,-1,2147483647,2147483647]
]);
Console.ReadLine();

public class Solution
{
    public void islandsAndTreasure(int[][] grid)
    {
        Queue<(int row, int column, int distance)> bfs = new();
        (int dx, int dy)[] directions = new (int dx, int dy)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        //Since we want to fill up all the Lands with the distance from it's nearest Treasure Chest, so we will actually enqueu the Treasure Chest coordinates and traverse from thos locations to their neighbor lands and fill up the distance.
        for (int row = 0; row < grid.Length; row++)
            for (int column = 0; column < grid[row].Length; column++)
                if (grid[row][column] == 0)
                    bfs.Enqueue((row, column, 0));

        while (bfs.Count > 0)
        {
            (int row, int column, int distance) = bfs.Dequeue();
            int distanceFromNearestTreasure = ++distance;

            foreach (var direction in directions)
            {
                (int nextRow, int nextColumn) = (row + direction.dx, column + direction.dy);

                //Out of bound
                if (nextRow < 0 || nextRow >= grid.Length || nextColumn < 0 || nextColumn >= grid[0].Length)
                    continue;

                //Can't traverse Land
                if (grid[nextRow][nextColumn] == -1)
                    continue;

                //Next grid is already nearer to another Treasure Chest, so no need to traverse from the current Treasure Chest
                if (grid[nextRow][nextColumn] <= distanceFromNearestTreasure)
                    continue;

                grid[nextRow][nextColumn] = distanceFromNearestTreasure;
                bfs.Enqueue((nextRow, nextColumn, distanceFromNearestTreasure));
            }
        }
    }
}