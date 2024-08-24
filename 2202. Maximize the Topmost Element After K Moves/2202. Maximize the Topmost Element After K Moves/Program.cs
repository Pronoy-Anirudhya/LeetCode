var nums = new int[] { 35, 43, 23, 86, 23, 45, 84, 2, 18, 83, 79, 28, 54, 81, 12, 94, 14, 0, 0, 29, 94, 12, 13, 1, 48, 85, 22, 95, 24, 5, 73, 10, 96, 97, 72, 41, 52, 1, 91, 3, 20, 22, 41, 98, 70, 20, 52, 48, 91, 84, 16, 30, 27, 35, 69, 33, 67, 18, 4, 53, 86, 78, 26, 83, 13, 96, 29, 15, 34, 80, 16, 49 };
//{ 99, 95, 68, 24, 18 };
Console.WriteLine(new Solution().MaximumTop(nums, 15));
Console.ReadLine();

public class Solution
{
    public int MaximumTop(int[] nums, int k)
    {
        var moveCount = 0;
        var maximumValue = -1;
        var index = 0;

        if (k == 0)
            return nums[index];

        if (nums.Length == 1 && k % 2 != 0)
            return -1;

        while (moveCount < (k - 1))
        {
            if (index < nums.Length - 1)
            {
                maximumValue = Math.Max(maximumValue, nums[index]);
            }
            else
            {
                maximumValue = Math.Max(maximumValue, nums[index]);
                break;
            }

            index++;
            moveCount++;
        }

        if ((index + 1) < nums.Length)
            maximumValue = Math.Max(maximumValue, nums[index + 1]);

        return maximumValue;
    }
}