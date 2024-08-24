Console.WriteLine(new Solution().FindMaxAverage(new int[] { 1, 12, -5, -6, 50, 3 }, 4));
Console.ReadLine();

public class Solution
{
    public double FindMaxAverage(int[] nums, int k)
    {
        long sum = 0, maxAverage;

        for (int i = 0; i < k; i++)
            sum += nums[i];

        maxAverage = sum;

        for (int i = k; i < nums.Length; i++)
        {
            sum += nums[i] - nums[i-k];
            maxAverage = Math.Max(maxAverage, sum);
        }

        return (double)maxAverage / k;
    }
}