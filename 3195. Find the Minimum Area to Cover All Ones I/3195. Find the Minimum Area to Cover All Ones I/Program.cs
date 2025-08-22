Console.WriteLine(new Solution().MinimumArea([[0, 1, 0], [1, 0, 1]]));
Console.ReadLine();

public class Solution
{
    public int MinimumArea(int[][] grid)
    {
        int fromTop = int.MaxValue, fromLeft = int.MaxValue;
        int fromBottom = int.MinValue, fromRight = int.MinValue;

        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[0].Length; col++)
            {
                // If the cell is 1, update the boundaries. We are looking for the smallest rectangle that covers all 1s. So for left and top, we take the minimum, and for right and bottom, we take the maximum.
                if (grid[row][col] == 1)
                {
                    fromTop = Math.Min(fromTop, row);
                    fromLeft = Math.Min(fromLeft, col);
                    fromBottom = Math.Max(fromBottom, row);
                    fromRight = Math.Max(fromRight, col);
                }
            }
        }

        // We are adding 1 to the right and bottom boundaries because the area is inclusive of the last row and column that contains a 1.
        int height = (fromBottom - fromTop) + 1, width = (fromRight - fromLeft) + 1;
        int area = height * width;

        return area;
    }
}