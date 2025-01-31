Console.WriteLine(new Solution().LargestIsland([[0, 1], [0, 1]]));
Console.ReadLine();

public class Solution
{
    /*
    Intuition: For every ZERO, we can consider it flipping and calculate the four-directional lands to get the length. This will be brute-force since there will be several recalculation to get the same Islands length. Instead, let us first calculate the Island length for the ONE's and store their length by assigning them an ID. Then we are gonna go through the ZERO's and add the four-directional Island lengths we have just calculated earlier if it has any.
    */

    public int LargestIsland(int[][] grid)
    {
        int maxIslandByFlippingZero = 0, maxIslandWithoutFlippingZero = 0, islandId = 2, n = grid.Length; //We are starting the IslandId from 2 since the grid has already 0 and 1 in it. And we are keeping the separate max Island length for ONE's (Phase-1) and ZERO's (Phase-2)
        Dictionary<int, int> islandLengthMap = [];
        (int dx, int dy)[] directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];

        //Phase-1: Here we will only go through if we found an ONE and calculate the length of this Island by connecting the subsequent ONE's
        for (int row = 0; row < n; row++)
        {
            for (int column = 0; column < n; column++)
            {
                //Not land or already has been visited
                if (grid[row][column] != 1)
                    continue;

                int currentIslandLength = BFSGetIslandLength(grid, directions, n, row, column, islandId);
                islandLengthMap[islandId] = currentIslandLength;
                maxIslandWithoutFlippingZero = Math.Max(maxIslandWithoutFlippingZero, currentIslandLength);
                islandId++;
            }
        }

        //Phase-2: Now we will only go through ZERO's and check if it has connected Islands four-directionally, whose length we have already precalculated and stored in the Dictionary to be used now without recalculating.
        for (int row = 0; row < n; row++)
        {
            for (int column = 0; column < n; column++)
            {
                //Part of an Island, so skip and continue till we find a ZERO
                if (grid[row][column] != 0)
                    continue;

                int islandLength = 1;
                HashSet<int> visitedIslandIds = [];

                for (int index = 0; index < directions.Length; index++)
                {
                    (int nextRow, int nextColumn) = (row + directions[index].dx, column + directions[index].dy);

                    //Out of bound
                    if (nextRow < 0 || nextRow >= n || nextColumn < 0 || nextColumn >= grid[0].Length)
                        continue;

                    int nextIslandId = grid[nextRow][nextColumn];

                    //This is to ensure we are notre-adding the same Islands length again since the ZERO could be surrounded by the same Island. In that case, we will only add if the surrounded Islands have distinc IDs. 
                    if (visitedIslandIds.Contains(nextIslandId))
                        continue;

                    if (islandLengthMap.TryGetValue(nextIslandId, out int length))
                    {
                        visitedIslandIds.Add(nextIslandId);
                        islandLength += length;
                    }
                }

                maxIslandByFlippingZero = Math.Max(maxIslandByFlippingZero, islandLength);
            }
        }

        return Math.Max(maxIslandByFlippingZero, maxIslandWithoutFlippingZero);
    }

    private int BFSGetIslandLength(int[][] grid, (int dx, int dy)[] directions, int n, int row, int column, int islandId)
    {
        int islandLength = 1;
        Queue<(int row, int column)> bfs = [];
        bfs.Enqueue((row, column));
        grid[row][column] = islandId;

        while (bfs.Count > 0)
        {
            var currentGrid = bfs.Dequeue();

            for (int index = 0; index < directions.Length; index++)
            {
                (int nextRow, int nextColumn) = (currentGrid.row + directions[index].dx, currentGrid.column + directions[index].dy);

                //Out of bound
                if (nextRow < 0 || nextRow >= n || nextColumn < 0 || nextColumn >= grid[0].Length)
                    continue;

                //Not part of an Island or has already been visited
                if (grid[nextRow][nextColumn] != 1)
                    continue;

                bfs.Enqueue((nextRow, nextColumn));
                grid[nextRow][nextColumn] = islandId;
                islandLength++;
            }
        }

        return islandLength;
    }
}