Console.WriteLine(new Solution().MaxSubArray([-2, 1, -3, 4, -1, 2, 1, -5, 4]));
Console.ReadLine();

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int maxSubArraySum = int.MinValue, currentSum = 0;

        /*
         * Kadane's Algorithm: Calculate currentSum by adding the i-th number and take the MAX value between them e.g. if current sum is -1 and i-th number is 1 then take 1 as currentSum.
         * After that, take the MAX between currentSum and MaxSum.
        */
        for (int i = 0; i < nums.Length; i++)
        {
            currentSum += nums[i];
            currentSum = Math.Max(currentSum, nums[i]);
            maxSubArraySum = Math.Max(maxSubArraySum, currentSum);
        }

        return maxSubArraySum;
    }
}