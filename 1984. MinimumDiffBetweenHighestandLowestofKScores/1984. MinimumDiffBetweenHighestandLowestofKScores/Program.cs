var nums = new int[] { 9, 4, 1, 7 };
Console.WriteLine(new Solution().MinimumDifference(nums, 2));
Console.ReadLine();

public class Solution
{
    public int MinimumDifference(int[] nums, int k)
    {
        var minimumDifference = int.MaxValue;
        var leftPointer = 0;
        var rightPointer = k - 1;
        Array.Sort(nums);

        if (k > nums.Length)
            return 0;

        while (rightPointer < nums.Length)
        {
            minimumDifference = Math.Min(minimumDifference, Math.Abs(nums[leftPointer] - nums[rightPointer]));
            leftPointer++;
            rightPointer++;
        }

        return minimumDifference;
    }
}