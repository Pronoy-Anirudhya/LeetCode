var nums = new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
Console.WriteLine(new Solution().ContainsDuplicate(nums));
Console.ReadLine();

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var numMap = new HashSet<int>();

        foreach (var number in nums)
        {
            if (numMap.Contains(number))
                return true;

            numMap.Add(number);
        }

        return false;
    }
}