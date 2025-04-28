Console.WriteLine(new Solution().CountSubarrays([5, 2, 6, 8, 9, 7], 50));
Console.ReadLine();

public class Solution
{
    public long CountSubarrays(int[] nums, long k)
    {
        long result = 0, sum = 0;

        for (int left = 0, right = 0; right < nums.Length; right++)
        {
            sum += nums[right];
            int length = right - left + 1;

            while (sum * length >= k && left <= right)
            {
                sum -= nums[left];
                left += 1;
                length = right - left + 1;
            }

            //Count of all the subarrays up to right can be derived by the formula stated below. Let's say we have [1, 2, 3, 4]
            //Up to 0: Subarray count is 1 ([1])
            //Up to 1: Subarray count is 3 ((Subarray count up to 0 which is 1) + (right - left + 1 which is 1 - 0 + 1) = 1 + 2 = 3)
            //Up to 2: Subarray count is 6 ((Subarray count up to 1 which is 3) + (right - left + 1 which is 2 - 0 + 1) = 3 + 3 = 6)
            //Up to 3: Subarray count is 10 ((Subarray count up to 2 which is 6) + (right - left + 1 which is 3 - 0 + 1) = 6 + 4 = 10)
            //Since we are adding to the existing result, so we are always adding to the Subarray count up to previous right and then the Subarray count up to current right.
            result += right - left + 1;
        }

        return result;
    }
}