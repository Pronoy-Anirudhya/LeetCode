int[] nums = new int[] { 1, 3, 4, 6 };
Console.WriteLine(new Solution().SearchInsert(nums, 5));
Console.ReadLine();

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        var middle = -1;

        while (left <= right)
        {
            middle = left + (right - left) / 2;

            if (nums[middle] == target)
                return middle;

            if (target > nums[middle])
            {
                left = middle + 1;
                ++middle;
            }
            else if (target < nums[middle])
                right = middle - 1;
        }

        return middle < 0 ? 0 : middle;
    }
}