Console.WriteLine(new Solution().LargestPerimeter([2, 1, 2]));
Console.ReadLine();

public class Solution
{
    public int LargestPerimeter(int[] nums)
    {
        var largestPerimeter = 0;
        Array.Sort(nums);

        for (int i = nums.Length - 1; i > 1; i--)
        {
            if (nums[i - 1] + nums[i - 2] > nums[i])
            {
                var currentPerimeter = nums[i] + nums[i-1] + nums[i-2];
                largestPerimeter = Math.Max(largestPerimeter, currentPerimeter);
            }
        }

        return largestPerimeter;
    }
}