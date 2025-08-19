Console.WriteLine(new Solution().ZeroFilledSubarray([0, 0, 0, 2, 0, 0]));
Console.ReadKey();

public class Solution
{
    public long ZeroFilledSubarray(int[] nums)
    {
        long result = 0;
        int consecutiveZeroes = 0;

        for (int index = 0; index < nums.Length; index++)
        {
            // If the current number is not zero, we check if we have counted any consecutive zeroes. If yes, we calculate the number of subarrays formed by those zeroes using the Traingular Number formula and reset the count.
            if (nums[index] != 0)
            {
                if (consecutiveZeroes > 0)
                {
                    result += GetSubarrayCount(consecutiveZeroes);
                    consecutiveZeroes = 0;
                }
            }
            else
                consecutiveZeroes++;
        }

        if (consecutiveZeroes > 0)
            result += GetSubarrayCount(consecutiveZeroes);

        return result;
    }

    private long GetSubarrayCount(int count)
    {
        return count == 0 ? 0 : (long)count * (count + 1) / 2; //This is the formula for the sum of the n triangular numbers "n(n+1)/2", in other words "Triangular Number".
    }
}