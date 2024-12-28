Console.WriteLine(new Solution().SwimInWater([[0, 1, 2, 3, 4], [24, 23, 22, 21, 5], [12, 13, 14, 15, 16], [11, 17, 18, 19, 20], [10, 9, 8, 7, 6]]));
Console.ReadLine();

public class Solution
{
    public int SwimInWater(int[][] grid)
    {
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
    }
}