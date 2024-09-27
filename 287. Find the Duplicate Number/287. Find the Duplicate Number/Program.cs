Console.WriteLine(new Solution().FindDuplicate([3, 1, 3, 4, 2]));
Console.ReadLine();

public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        int slow = 0, fast = 0;

        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        fast = 0;

        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }
}