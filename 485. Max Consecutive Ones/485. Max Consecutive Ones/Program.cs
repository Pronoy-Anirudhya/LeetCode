Console.WriteLine(new Solution().FindMaxConsecutiveOnes([1, 1, 0, 1, 1, 1]));
Console.ReadLine();

public class Solution
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int maxConsecutiveOneCount = int.MinValue, currentConsecutiveOneCount = 0;

        for (int index = 0; index < nums.Length; index++)
        {
            if (nums[index] == 1)
                currentConsecutiveOneCount++;
            else
            {
                maxConsecutiveOneCount = Math.Max(maxConsecutiveOneCount, currentConsecutiveOneCount);
                currentConsecutiveOneCount = 0;
            }
        }

        return Math.Max(maxConsecutiveOneCount, currentConsecutiveOneCount);
    }
}