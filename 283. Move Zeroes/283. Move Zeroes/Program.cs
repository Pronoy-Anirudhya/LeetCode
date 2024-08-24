new Solution().MoveZeroes(new int[] { 1, 0, 1 }); //0, 0, 0, 3, 12 1 1 2 0 0 3
Console.ReadLine();

public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        var index = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[index] = nums[i];
                index++;
            }
        }

        for (int i = index; i < nums.Length; i++)
            nums[i] = 0;
    }
}