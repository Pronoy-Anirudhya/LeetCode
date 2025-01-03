Console.WriteLine(new Solution().WaysToSplitArray([-1, -2]));
Console.ReadLine();

public class Solution
{
    public int WaysToSplitArray(int[] nums)
    {
        int validWays = 0;
        long[] prefixSum = new long[nums.Length];
        long sumTillNow = 0;

        for (int index = 0; index < nums.Length; index++)
        {
            sumTillNow += nums[index];
            prefixSum[index] = sumTillNow;
        }

        for (int index = 0; index < nums.Length - 1; index++)
        {
            long sumUpToFirstPart = prefixSum[index];
            long sumUpToLastPartExcludingFirstPartSum = prefixSum[nums.Length - 1] - sumUpToFirstPart;

            if (sumUpToFirstPart >= sumUpToLastPartExcludingFirstPartSum)
                validWays++;
        }

        return validWays;
    }
}