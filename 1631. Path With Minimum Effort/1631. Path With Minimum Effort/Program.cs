Console.WriteLine(new Solution().MinimumEffortPath([[4, 3, 4, 10, 5, 5, 9, 2], [10, 8, 2, 10, 9, 7, 5, 6], [5, 8, 10, 10, 10, 7, 4, 2], [5, 1, 3, 1, 1, 3, 1, 9], [6, 4, 10, 6, 10, 9, 4, 6]]));
Console.ReadLine();

public class Solution
{
    public int MinimumEffortPath(int[][] heights)
    {
        int minimumEffort = int.MaxValue;
        PriorityQueue<(int row, int column, int effort), int> minHeap = new();
        bool[,] visited = new bool[heights.Length, heights[0].Length];
        (int dx, int dy)[] directions = [(0, -1), (0, 1), (-1, 0), (1, 0)];//LEFT, RIGHT, UP, DOWN
        minHeap.Enqueue((0, 0, 0), 0);

        while (minHeap.Count > 0)
        {
            (int row, int column, int effort) = minHeap.Dequeue();

            //We will be using Dijkstra's Algorithm here. So when we are popping one coordinate from the minHeap, only then we will include that in the visited boolean array so that doesn't get visited again.
            visited[row, column] = true;

            foreach (var direction in directions)
            {
                int nextRow = row + direction.dx;
                int nextColumn = column + direction.dy;

                //If the next coordinates are out of bound, then skip and continue.
                if (nextRow < 0 || nextRow >= heights.Length || nextColumn < 0 || nextColumn >= heights[nextRow].Length)
                    continue;

                //We have to keep the MAX height distance aka Effort so far along this path. That's why checking which is greater, the effort so far or the new effort that will be required to go from this point to the next coordinate.
                int newEffort = Math.Max(effort, Math.Abs(heights[row][column] - heights[nextRow][nextColumn]));

                //If the next coordinate is already visited, then skip and continue.
                if (visited[nextRow, nextColumn])
                    continue;

                //If it is the destination coordinate, then check whether this path produced the MINIMUM effort or any other previous path had the miimum effort. Then no need to include this in the minHeap or Visited array since this is our destination and we want to know for each unique path to reach here. Including it in the visited array would prevent that from happening.
                if (nextRow == heights.Length - 1 && nextColumn == heights[nextRow].Length - 1)
                {
                    minimumEffort = Math.Min(minimumEffort, newEffort);
                    continue;
                }

                minHeap.Enqueue((nextRow, nextColumn, newEffort), newEffort); 
            }
        }

        return minimumEffort == int.MaxValue ? 0 : minimumEffort; //For edge cases where the grid only contains one value. So the minimumEffort will never get updated. To avoid this, we need to check and assign 0 in that case.
    }
}