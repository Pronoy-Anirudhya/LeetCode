Console.WriteLine(new Solution().IsArraySpecial([4, 3, 1, 6]));
Console.ReadLine();

public class Solution
{
    public bool IsArraySpecial(int[] nums)
    {
        int left = 0, right = 1;

        while (right < nums.Length)
        {
            if (nums[left] % 2 == nums[right] % 2)
                return false;

            left++;
            right++;
        }

        return true;
    }
}