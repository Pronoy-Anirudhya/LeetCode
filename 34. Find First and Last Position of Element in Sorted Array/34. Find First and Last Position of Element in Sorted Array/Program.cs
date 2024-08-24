var nums = new int[] { 8, 8, 8, 8, 8, 8 };
Console.WriteLine(new Solution().SearchRange(nums, 8));

public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var result = new int[2];

        result[0] = GetStartIndex(nums, target);
        result[1] = GetEndIndex(nums, target);

        return result;
    }

    public int GetStartIndex(int[] nums, int target)
    {
        var startIndex = -1;

        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                startIndex = mid;
                right = mid - 1;
            }
            else if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
        }

        return startIndex;
    }

    public int GetEndIndex(int[] nums, int target)
    {
        var endIndex = -1;

        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                endIndex = mid;
                left = mid + 1;
            }
            else if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
        }

        return endIndex;
    }
}