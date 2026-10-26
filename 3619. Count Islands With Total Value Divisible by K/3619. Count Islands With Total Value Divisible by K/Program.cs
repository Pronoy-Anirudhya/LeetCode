Console.WriteLine(new Solution().CountIslands([[0, 2, 1, 0, 0], [0, 5, 0, 0, 5], [0, 0, 1, 0, 0], [0, 1, 4, 7, 0], [0, 2, 0, 0, 8]], 5));
Console.ReadLine();

public class Solution
{
    public int CountIslands(int[][] grid, int k)
    {
        int validIslands = 0;

        for (int row = 0; row < grid.Length; row++)
        {
            for (int column = 0; column < grid[row].Length; column++)
            {
                // If the current cell is 0, skip it since it is not part of an island.
                if (grid[row][column] == 0)
                    continue;

                // Perform BFS to check if the island's total value is divisible by k.
                if (BfsIsIslandDivisibleByK(grid, k, row, column))
                    validIslands++; // Increment the count of valid islands if the total value is divisible by k.
            }
        }

        return validIslands;
    }

    private bool BfsIsIslandDivisibleByK(int[][] grid, int k, int row, int column)
    {
        long totalIslandValue = grid[row][column]; // Initialize the total value of the island with the value of the starting cell.
        Queue<(int row, int column)> bfs = [];
        (int dx, int dy)[] directions = [(0, 1), (0, -1), (1, 0), (-1, 0)]; // Directions for moving right, left, down, and up.

        bfs.Enqueue((row, column));
        grid[row][column] = 0; // Mark the current cell as visited by setting it to 0.

        while (bfs.Count > 0)
        {
            var currentGrid = bfs.Dequeue();

            foreach (var direction in directions)
            {
                int nextRow = currentGrid.row + direction.dx;
                int nextColumn = currentGrid.column + direction.dy;

                // Check if the next cell is out of bounds. If so, skip it.
                if (nextRow < 0 || nextRow >= grid.Length || nextColumn < 0 || nextColumn >= grid[nextRow].Length)
                    continue;

                // Check if the next cell is 0. If so, skip it.
                if (grid[nextRow][nextColumn] == 0)
                    continue;

                // If the next cell is part of the island, enqueue it and add its value to the total island value.
                bfs.Enqueue((nextRow, nextColumn));
                totalIslandValue += grid[nextRow][nextColumn];
                grid[nextRow][nextColumn] = 0; // Mark the next cell as visited by setting it to 0. Otherwise we would add its value to totalIslandValue multiple times.
            }
        }

        return totalIslandValue % k == 0; // Return true if the total island value is divisible by k, otherwise return false.
    }
}