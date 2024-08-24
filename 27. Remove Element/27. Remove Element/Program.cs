var nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
var val = 2;
Console.WriteLine(new Solution().RemoveElement(nums, val));
Console.ReadLine();

public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        var countAfterRemoval = 0;
        var index = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
                continue;

            nums[index] = nums[i];
            countAfterRemoval++;
            index++;
        }

        return countAfterRemoval;
    }
}