new Solution().SortColors(new int[] { 2, 0, 2, 1, 1, 0 });
Console.ReadLine();

public class Solution
{
    public void SortColors(int[] nums)
    {
        var redCount = 0; //0
        var whiteCount = 0; //1
        var blueCount = 0; //2

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                redCount++;
            else if (nums[i] == 1)
                whiteCount++;
            else if (nums[i] == 2)
                blueCount++;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (redCount > 0)
            {
                nums[i] = 0;
                redCount--;
            }
            else if (whiteCount > 0)
            {
                nums[i] = 1;
                whiteCount--;
            }
            else if (blueCount > 0)
            {
                nums[i] = 2;
                blueCount--;
            }
        }
    }
}