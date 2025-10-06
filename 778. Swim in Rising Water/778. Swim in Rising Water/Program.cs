Console.WriteLine(new Solution().SwimInWater([[0, 1, 2, 3, 4], [24, 23, 22, 21, 5], [12, 13, 14, 15, 16], [11, 17, 18, 19, 20], [10, 9, 8, 7, 6]]));
Console.ReadLine();

public class Solution
{
    public int SwimInWater(int[][] grid)
    {
        int maximumTimeToReachDestination = 0; // This variable is used to keep track of the maximum time required to reach the destination grid.
        PriorityQueue<Grid, int> minHeap = new(); // MinHeap to always expand the least time consuming path first.
        bool[,] visited = new bool[grid.Length, grid[0].Length];
        (int dx, int dy)[] directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];
        minHeap.Enqueue(new Grid(0, 0, grid[0][0]), grid[0][0]);

        while (minHeap.Count > 0)
        {
            Grid currentGrid = minHeap.Dequeue();
            maximumTimeToReachDestination = Math.Max(maximumTimeToReachDestination, grid[currentGrid.row][currentGrid.column]); // Since we can only move to a grid if the time is greater than or equal to the grid value, we need to keep track of the maximum time required to reach the destination grid. If we reach the destination grid, we return this value as the result. If we never reach the destination grid, we return this value as the result.

            // If we have reached the destination grid, we return the maximum time required to reach the destination grid.
            if (currentGrid.row == grid.Length - 1 && currentGrid.column == grid[0].Length - 1)
                return maximumTimeToReachDestination; // Since we were maintaining a minHeap, so the destination coordination getting popped out means this is the minimum possible time. Any other path leading to the destination will never be smaller than this for sure.

            visited[currentGrid.row, currentGrid.column] = true; // Mark the current grid as visited. We do this after checking if we have reached the destination grid because we might reach the destination grid multiple times through different paths, but we only want to return the first time we reach it, which is guaranteed to be the minimum time due to the minHeap.

            for (int index = 0; index < directions.Length; index++)
            {
                int nextRow = currentGrid.row + directions[index].dx, nextColumn = currentGrid.column + directions[index].dy;

                // Checking if the next grid is out of bound or has already been visited. If so, we skip it.
                if (isGridOutOfBound(nextRow, nextColumn, grid.Length, grid[0].Length) || visited[nextRow, nextColumn])
                    continue;

                visited[nextRow, nextColumn] = true; // Once added to the minHeap, it is not needed to visit again since we are actually not calculating the distance between grids. We are just rather checking whichever grid has higher number. So that number of times is actually need to reach there.
                minHeap.Enqueue(new Grid(nextRow, nextColumn, grid[nextRow][nextColumn]), grid[nextRow][nextColumn]);
            }
        }

        return maximumTimeToReachDestination;
    }

    private bool isGridOutOfBound(int row, int column, int rowLength, int columnLength)
    {
        return row < 0 || row >= rowLength || column < 0 || column >= columnLength;
    }
}

public record Grid(int row, int column, int timeToReachSoFar);

//Previous Solution
/*
PriorityQueue<(int row, int column, int timeRequiredTillNow), int> minHeap = new();
bool[,] visited = new bool[grid.Length, grid[0].Length];
(int dx, int dy)[] directions = [(0,-1), (0, 1), (-1, 0), (1, 0)];

minHeap.Enqueue((0, 0, grid[0][0]), grid[0][0]);

while (minHeap.Count > 0)
{
    (int row, int column, int timeRequiredTillNow) = minHeap.Dequeue();
    visited[row, column] = true;

    if (row == grid.Length - 1 && column == grid[0].Length - 1)
        return timeRequiredTillNow; // Since we were maintaining a minHeap, so the destination coordination getting popped out means this is the minimum possible time. Any other path leading to the destination will never be smaller than this for sure.

    foreach (var direction in directions)
    {
        (int nextRow, int nextColumn) = (row + direction.dx, column + direction.dy);

        //Checking if the next grid is out of bound
        if (nextRow < 0 || nextRow >= grid.Length || nextColumn < 0 || nextColumn >= grid[0].Length)
            continue;

        //Checking whether the next grid has already been visited
        if (visited[nextRow, nextColumn])
            continue;

        int timeRequiredToGoToNextGrid = Math.Max(timeRequiredTillNow, grid[nextRow][nextColumn]); //Whichever is greater, that will be the time required till now to get to the next grid.
        minHeap.Enqueue((nextRow, nextColumn, timeRequiredToGoToNextGrid), timeRequiredToGoToNextGrid);
        visited[nextRow, nextColumn] = true; //Once added to the minHeap, it is not needed to visit again since we are actually not calculating the distance between grids. We are just rather checking whichever grid has higher number. So that number of times is actually need to reach there. 
    }
}

return 0; //The code will reach here if and only if there was not but a single grid in the matrix, in which case the time required is ZERO. 
*/