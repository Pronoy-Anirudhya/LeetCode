int[] nums = { 4, 2, 0, 0, 1, 1, 4, 4, 4, 0, 4, 0 };
Console.WriteLine(new Solution().CanJump(nums));
Console.ReadLine();

public class Solution
{
    public bool CanJump(int[] nums)
    {
        int targetJumpIndex = nums.Length - 1;
        int index = targetJumpIndex - 1;

        while (index >= 0)
        {
            int jumpLength = index + nums[index];

            if (jumpLength >= targetJumpIndex)
                targetJumpIndex = index;

            index--;
        }

        return targetJumpIndex == 0;
    }
}