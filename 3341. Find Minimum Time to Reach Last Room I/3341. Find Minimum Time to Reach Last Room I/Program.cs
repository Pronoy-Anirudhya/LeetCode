Console.WriteLine(new Solution().MinTimeToReach([[0, 4], [4, 4]]));
Console.ReadLine();

public class Solution
{
    public int MinTimeToReach(int[][] moveTime)
    {
        int gridRowLength = moveTime.Length, gridColumnLength = moveTime[0].Length;
        PriorityQueue<(int row, int column, int timeTillNow), int> minHeap = new();
        int[,] minimumTimeToReach = new int[gridRowLength, gridColumnLength];
        (int dx, int dy)[] directions = [(0, 1), (1, 0), (-1, 0), (0, -1)];

        //We will be using modified Dijkstra's algorithm, basically with Priorotu Queue MinHeap. That's why we are initializing the distance array with INFINITY at first.
        for (int row = 0; row < gridRowLength; row++)
            for (int column = 0; column < gridColumnLength; column++)
                minimumTimeToReach[row, column] = int.MaxValue;

        //No matter what the value is, to reach the first grid (0, 0), time taken in 0.
        minHeap.Enqueue((0, 0, 0), 0);

        while (minHeap.Count > 0)
        {
            var grid = minHeap.Dequeue();

            //Since we have always been maintain a MinHeap and popping the shortest time taken for any path, so if we reached the right bottom grid, we can say this is the minimum time taken path and just return the current time taken value till now.
            if (grid.row == gridRowLength - 1 && grid.column == gridColumnLength - 1)
                return grid.timeTillNow;

            for (int index = 0; index < directions.Length; index++)
            {
                (int nextRow, int nextColumn) = (grid.row + directions[index].dx, grid.column + directions[index].dy);

                //Out of bound
                if (nextRow < 0 || nextRow >= gridRowLength || nextColumn < 0 || nextColumn >= gridColumnLength)
                    continue;
                
                //To go to the next grid, we will take the MAX time between the time taken till now to reach this grid and the move time of next grid. Whichever is greater, we will take that and add 1 to it since the cost of moving to any grid is 1 minute.
                int nextTimeTillNow = Math.Max(grid.timeTillNow, moveTime[nextRow][nextColumn]) + 1;

                //If the time to reach next grid is smaller than the time to reach that grid calculated so far, this means we have found a more shorter path that takes less time. So we update the minimum time taken to reach to that grid value with the smaller time and add that grid to the queue since it can lead to further shortest time paths down the line.
                if (minimumTimeToReach[nextRow, nextColumn] > nextTimeTillNow)
                {
                    minimumTimeToReach[nextRow, nextColumn] = nextTimeTillNow;
                    minHeap.Enqueue((nextRow, nextColumn, nextTimeTillNow), nextTimeTillNow);
                }
            }
        }

        return minimumTimeToReach[gridRowLength - 1, gridColumnLength - 1];
    }
}