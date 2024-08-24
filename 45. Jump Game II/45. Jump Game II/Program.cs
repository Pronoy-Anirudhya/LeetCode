Console.WriteLine(new Solution().Jump(new int[] { 1,1,1,1 }));
Console.ReadLine();

public class Solution
{
    public int Jump(int[] nums)
    {
        if (nums.Length == 1)
            return 0;

        for (int i = 0; i < nums.Length; i++)
            nums[i] = i + nums[i];

        int currentWindow = nums[0];
        int currentWindowMax = 0;
        int jumpCount = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            currentWindowMax = Math.Max(currentWindowMax, nums[i]);

            if (i == currentWindow || i == nums.Length - 1)
            {
                jumpCount++;
                currentWindow = currentWindowMax;
            }
        }

        return jumpCount;
    }
}