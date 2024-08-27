using System.Security.AccessControl;

Console.WriteLine(new Solution().FindMaxK([-10, 8, 6, 7, -2, -3]));
Console.ReadLine();

public class Solution
{
    public int FindMaxK(int[] nums)
    {
        var result = -1;
        var numSet = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!numSet.Contains(nums[i]))
            {
                numSet.Add(nums[i]);

                if (numSet.Contains(-nums[i]))
                    result = Math.Max(result, Math.Abs(nums[i]));
            }
        }
        
        return result;
    }
}
