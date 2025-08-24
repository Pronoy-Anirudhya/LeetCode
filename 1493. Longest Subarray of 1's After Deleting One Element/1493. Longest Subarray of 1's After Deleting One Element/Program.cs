Console.WriteLine(new Solution().LongestSubarray([0, 1, 1, 1, 0, 1, 1, 0, 1]));
Console.ReadLine();

public class Solution
{
    public int LongestSubarray(int[] nums)
    {
        int left = 0, right = 0, zeroCount = 0, longestSubarray = 0;

        while (right < nums.Length)
        {
            // Since we have to delete one element, we count the number of 0s in the window. And we allow at most one 0 in the window.
            if (nums[right] == 0)
                zeroCount++;

            // If we have more than one 0 in the window, we move the left pointer to the right until we have at most one 0 in the window.
            while (zeroCount > 1)
            {
                if (nums[left] == 0)
                    zeroCount--;

                left++;
            }

            // We update the longest subarray length. We do not count the 0 in the window, so the length is right - left.
            int currentLongestSubarray = right - left;
            longestSubarray = Math.Max(longestSubarray, currentLongestSubarray);
            right++;
        }

        return longestSubarray;
    }
}