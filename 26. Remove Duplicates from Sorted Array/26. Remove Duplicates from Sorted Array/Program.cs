var nums = new int[] { 1, 1, 2, 3, 3, 4, 5, 5, 6, 7, 7, 8 }; // 8
Console.WriteLine(new Solution().RemoveDuplicates(nums));
Console.ReadLine();

public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        var uniqueNumberCount = 1;
        var index = 1;
        var currentNumber = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == currentNumber)
                continue;

            nums[index] = nums[i];
            currentNumber = nums[i];
            uniqueNumberCount++;
            index++;
        }

        return uniqueNumberCount;
    }
}