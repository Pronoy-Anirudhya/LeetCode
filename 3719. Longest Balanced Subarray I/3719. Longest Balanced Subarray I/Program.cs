Console.WriteLine(new Solution().LongestBalanced([10, 6, 10, 7]));
Console.ReadLine();

public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int longestBalancedSubarrayLength = 0;

        // The outer loop selects the starting index of the subarray. The inner loop extends the subarray to the right. In each iteration of the inner loop, we check if the current subarray is balanced by comparing the counts of unique even and odd numbers using two hash sets. Intuitively, this approach ensures that we explore all possible subarrays and keep track of the longest balanced one found.
        for (int left = 0; left < nums.Length; left++)
        {
            HashSet<int> evenNumbers = [];
            HashSet<int> oddNumbers = [];

            for (int right = left; right < nums.Length; right++)
            {
                bool isEvenNumber = nums[right] % 2 == 0;

                // Add the number to the appropriate set based on its parity
                if (isEvenNumber)
                {
                    if (!evenNumbers.Contains(nums[right]))
                        evenNumbers.Add(nums[right]);
                }
                else
                {
                    if (!oddNumbers.Contains(nums[right]))
                        oddNumbers.Add(nums[right]);
                }

                if (evenNumbers.Count == oddNumbers.Count)
                    longestBalancedSubarrayLength = Math.Max(longestBalancedSubarrayLength, right - left + 1);
            }
        }
        
        return longestBalancedSubarrayLength;
    }
}