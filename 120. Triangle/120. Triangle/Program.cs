Console.WriteLine(new Solution().MinimumTotal([[2], [3, 4], [6, 5, 7], [4, 1, 8, 3]]));
Console.ReadLine();

public class Solution
{
    // Dijkstra's algorithm approach using a priority queue (min-heap).
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        if (triangle == null || triangle.Count == 0)
            return 0;

        int minimumPathTotal = int.MaxValue, triangleTotalRowLength = triangle.Count;
        (int row, int column)[] directions = [(1, 0), (1, 1)]; // Possible moves: down-left and down-right.

        // minCostToReach[r][c] will hold the minimum cost to reach cell (r, c).
        int[][] minCostToReach = new int[triangleTotalRowLength][];

        for (int row = 0; row < triangleTotalRowLength; row++)
        {
            minCostToReach[row] = new int[triangle[row].Count];

            for (int column = 0; column < triangle[row].Count; column++)
                minCostToReach[row][column] = int.MaxValue; // Initialize with infinity (or a very large number) so that any path cost will be lower later. This is crucial for Dijkstra's algorithm to work correctly.
        }

        PriorityQueue<Path, int> minHeap = new(); // Min-heap priority queue to explore paths in order of increasing cost.
        minHeap.Enqueue(new Path(0, 0, triangle[0][0]), triangle[0][0]);
        minCostToReach[0][0] = triangle[0][0];
 
        while (minHeap.Count > 0)
        {
            Path currentPath = minHeap.Dequeue();

            // If the cost of the current path is greater than the minimum cost recorded for this cell, skip processing it. This ensures we only process the most optimal paths.
            if (currentPath.cost > minCostToReach[currentPath.row][currentPath.column])
                continue;

            // If we've reached the last row, update the minimum path total if this path is cheaper. We don't stop here because there might be other paths to explore that could be cheaper.
            if (currentPath.row == triangleTotalRowLength - 1)
            {
                minimumPathTotal = Math.Min(minimumPathTotal, currentPath.cost);
                continue;
            }

            // Explore the two possible moves from the current position.
            foreach (var (dr, dc) in directions)
            {
                int newRow = currentPath.row + dr;
                int newColumn = currentPath.column + dc;

                // Check if the new position is within bounds.
                if (newRow < triangleTotalRowLength && newColumn <= newRow)
                {
                    int newCost = currentPath.cost + triangle[newRow][newColumn];

                    // If this new path to (newRow, newColumn) is cheaper than any previously found path, update its minimum cost and enqueue it for future exploration.
                    if (newCost < minCostToReach[newRow][newColumn])
                    {
                        minCostToReach[newRow][newColumn] = newCost;
                        minHeap.Enqueue(new Path(newRow, newColumn, newCost), newCost);
                    }
                }
            }
        }

        return minimumPathTotal;
    }
}

public record Path(int row, int column, int cost);