Console.WriteLine(new Solution().PacificAtlantic([[1, 2, 3], [8, 9, 4], [7, 6, 5]]));
Console.ReadLine();

public class Solution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        List<IList<int>> result = [];
        Queue<(int row, int column)> bfsQueueForPacific = [];
        Queue<(int row, int column)> bfsQueueForAtlantic = [];
        bool[][] pacific = new bool[heights.Length][];
        bool[][] atlantic = new bool[heights.Length][];

        //Setting Pacific & Atlantic boundary as TRUE
        for (int row = 0; row < heights.Length; row++)
        {
            pacific[row] = new bool[heights[0].Length];
            atlantic[row] = new bool[heights[0].Length];

            for (int column = 0; column < heights[row].Length; column++)
            {
                //Top row and left column grids can flow water to Pacific, that's why setting them TRUE for Pacific
                if (row == 0 || column == 0)
                {
                    pacific[row][column] = true;
                    bfsQueueForPacific.Enqueue((row, column));
                }

                //Bottom row and right column grids can flow water to Atlantic, that's why setting them TRUE for Atlantic
                if (row == heights.Length - 1 || column == heights[0].Length - 1)
                {
                    atlantic[row][column] = true;
                    bfsQueueForAtlantic.Enqueue((row, column));
                }
            }
        }

        //Process Pacific BFS Queue to see whether their adjacent grids can flow water to them. If yes, then set their corresponding values in boolean Pacific matrix as TRUE and add them in the queue
        BFS(bfsQueueForPacific, heights, pacific);

        //Process Atlantic BFS Queue to see whether their adjacent grids can flow water to them. If yes, then set their corresponding values in boolean Atlantic matrix as TRUE and add them in the queue
        BFS(bfsQueueForAtlantic, heights, atlantic);

        for (int row = 0; row < heights.Length; row++)
        {
            for (int column = 0; column < heights[row].Length; column++)
            {
                //If both of the Pacific & Atlantic matrix for this grid is TRUE then we can say that from this grid, water can flow to both Pacific & Atlantic, hence adding it to the result
                if (pacific[row][column] && atlantic[row][column])
                    result.Add([row, column]);
            }
        }

        return result;
    }

    private void BFS(Queue<(int row, int column)> bfsQueue, int[][] heights, bool[][] matrix)
    {
        (int dx, int dy)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];

        while (bfsQueue.Count > 0)
        {
            (int row, int column) = bfsQueue.Dequeue();

            for (int index = 0; index < directions.Length; index++)
            {
                int visitingRow = row + directions[index].dx;
                int visitingColumn = column + directions[index].dy;

                if (visitingRow < 0 || visitingRow >= heights.Length || visitingColumn < 0 || visitingColumn >= heights[0].Length || matrix[visitingRow][visitingColumn])
                    continue;

                int currentHeight = heights[row][column];
                int visitingHeight = heights[visitingRow][visitingColumn];

                if (visitingHeight >= currentHeight)
                {
                    matrix[visitingRow][visitingColumn] = true;
                    bfsQueue.Enqueue((visitingRow, visitingColumn));
                }
            }
        }
    }
}