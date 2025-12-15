Console.WriteLine(new Solution().GetDescentPeriods([3, 2, 1, 4]));
Console.ReadLine();

public class Solution
{
    public long GetDescentPeriods(int[] prices)
    {
        long descentPeriods = 0;
        int count = 0; // Count of current smooth descent period.

        for (int i = 0; i < prices.Length; i++)
        {
            // If it's the start of the array or continues the descent period. So we increment the count.
            if (i == 0 || prices[i] == prices[i - 1] - 1)
                count++;
            else
                count = 1; // Reset count if the descent period is broken. Since the current price itself is a descent period.

            descentPeriods += count; // Add the count to the total descent periods. It includes all sub-periods ending at the current price. I.e., for count = 3, we have 3 (itself), 2 (last two), 1 (all three). It forms an arithmetic series. It works because every time we extend the descent period, we add all new sub-periods that end at the current price.
        }

        return descentPeriods;
    }
}