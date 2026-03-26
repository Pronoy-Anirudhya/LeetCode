Console.WriteLine(new Solution().CanPartitionGrid([[28443], [33959]]));
Console.ReadLine();

public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        long[] horizontalSums = new long[grid.Length], verticalSums = new long[grid[0].Length]; // Horizontal sums for each row and vertical sums for each column.
        long totalSum = 0;

        // We are iterating through each cell in the grid and adding its value to the corresponding row sum, column sum, and the total sum of the grid. This allows us to efficiently compute the sums needed for later comparisons without having to iterate through the grid multiple times. After this loop, we will have the total sum of the grid and the sums of each row and column, which we can then use to check for possible partitions.
        for (int row = 0; row < grid.Length; row++)
        {
            for (int column = 0; column < grid[row].Length; column++)
            {
                horizontalSums[row] += grid[row][column]; // Add the value to the corresponding row sum.
                verticalSums[column] += grid[row][column]; // Add the value to the corresponding column sum.
                totalSum += grid[row][column]; // Add the value to the total sum of the grid.
            }
        }

        long horizontalSumFromLeft = 0, verticalSumFromLeft = 0;

        // Intuition: We are iterating through the horizontal sums and vertical sums to check if there is a point where the sum from the left equals the sum from the right. If we find such a point, we return true. If the sum from the left exceeds the sum from the right at any point, we can break out of the loop early since it will not be possible for them to be equal further down the line. This allows us to efficiently determine if there is a valid partition of the grid. We are separately checking the horizontal and vertical sums to account for both possible partition orientations (horizontal and vertical). If we find a valid partition in either orientation, we can return true. If we finish iterating through both orientations without finding a valid partition, we return false.
        for (int index = 0; index < horizontalSums.Length; index++)
        {
            horizontalSumFromLeft += horizontalSums[index];
            long horizontalRightSideSumFromLeft = totalSum - horizontalSumFromLeft; // Calculate the sum of the right side by subtracting the left sum from the total sum.

            // If the sum from the left equals the sum from the right, we have found a valid partition and can return true.
            if (horizontalSumFromLeft == horizontalRightSideSumFromLeft)
                return true;

            // If the sum from the left exceeds the sum from the right, we can break out of the loop early since it will not be possible for them to be equal further down the line.
            if (horizontalSumFromLeft > horizontalRightSideSumFromLeft)
                break;
        }

        for (int index = 0; index < verticalSums.Length; index++)
        {
            verticalSumFromLeft += verticalSums[index];
            long verticalRightSideSumFromLeft = totalSum - verticalSumFromLeft; // Calculate the sum of the right side by subtracting the left sum from the total sum.

            // If the sum from the left equals the sum from the right, we have found a valid partition and can return true.
            if (verticalSumFromLeft == verticalRightSideSumFromLeft)
                return true;
            
            // If the sum from the left exceeds the sum from the right, we can break out of the loop early since it will not be possible for them to be equal further down the line.
            if (verticalSumFromLeft > verticalRightSideSumFromLeft)
                break;
        }

        return false; // If we have iterated through all possible partitions and have not found any valid ones, we return false.
    }
}