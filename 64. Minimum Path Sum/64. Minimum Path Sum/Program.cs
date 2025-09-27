Console.WriteLine(new Solution().MinPathSum([[1, 2, 3], [4, 5, 6]]));
Console.ReadLine();

public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        int minimumPathSum = int.MaxValue;
        bool[][] visited = new bool[grid.Length][];
        PriorityQueue<Path, int> minHeap = new();
        (int dx, int dy)[] directions = [(1, 0), (0, 1)];
        minHeap.Enqueue(new Path(0, 0, grid[0][0]), grid[0][0]); // Start from the top-left corner with the initial path sum being the value of the starting cell.

        while (minHeap.Count > 0)
        {
            Path path = minHeap.Dequeue();

            // If we reached the bottom-right corner, update the minimum path sum. We do not return immediately because there might be a path with a smaller sum. We continue exploring other paths until the min-heap is empty. This ensures we find the absolute minimum path sum.
            if (path.row == grid.Length - 1 && path.column == grid[grid.Length - 1].Length - 1)
                minimumPathSum = Math.Min(minimumPathSum, path.pathSumSoFar);

            if (visited[path.row] == null)
                visited[path.row] = new bool[grid[path.row].Length]; // Initialize the row if it hasn't been initialized yet.

            // If we've already visited this cell, skip it. This prevents cycles and redundant calculations. We only want to process each cell once with the minimum path sum found so far. This is crucial for the efficiency of the algorithm.
            if (visited[path.row][path.column])
                continue;

            visited[path.row][path.column] = true; // Mark the cell as visited.

            // Explore the neighboring cells (down and right) and add them to the min-heap if they are within bounds.
            foreach (var direction in directions)
            {
                int nextRow = path.row + direction.dx, nextColumn = path.column + direction.dy;

                // Check if the next cell is within the grid bounds. If not, skip it.
                if (nextRow >= grid.Length || nextColumn >= grid[grid.Length - 1].Length)
                    continue;

                int nextPathSumSoFar = path.pathSumSoFar + grid[nextRow][nextColumn]; // Calculate the new path sum including the next cell's value.
                minHeap.Enqueue(new Path(nextRow, nextColumn, nextPathSumSoFar), nextPathSumSoFar);
            }
        }

        return minimumPathSum;
    }
}

public record Path(int row, int column, int pathSumSoFar);