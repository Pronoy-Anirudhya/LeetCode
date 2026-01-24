Console.WriteLine(new Solution().MinPairSum([3, 4, 6, 7]));
Console.ReadLine();

public class Solution
{
    public int MinPairSum(int[] nums)
    {
        int minimumPairSum = int.MinValue; // Initialize to the smallest possible integer value.
        Array.Sort(nums); // Sort the array in ascending order. This helps in pairing the smallest and largest elements together.

        for (int left = 0, right = nums.Length - 1; left < right; left++, right--)
        {
            int currentPairSum = nums[left] + nums[right];
            minimumPairSum = Math.Max(minimumPairSum, currentPairSum); // Update the maximum pair sum found so far.
        }

        return minimumPairSum;
    }
}