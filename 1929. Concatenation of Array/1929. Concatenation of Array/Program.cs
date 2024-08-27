Console.WriteLine(new Solution().GetConcatenation([1, 3, 2, 1]));
Console.ReadLine();

public class Solution
{
    public int[] GetConcatenation(int[] nums)
    {
        var resultArray = new int[nums.Length * 2];

        for (int i = 0; i < nums.Length; i++)
        {
            resultArray[i] = nums[i];
            resultArray[i + nums.Length] = nums[i];
        }

        return resultArray;
    }
}