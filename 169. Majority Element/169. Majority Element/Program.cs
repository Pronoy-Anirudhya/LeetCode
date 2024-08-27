var nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
Console.WriteLine(new Solution().MajorityElement(nums));
Console.ReadLine();

public class Solution
{
    public int MajorityElement(int[] nums)
    {
        if (nums.Length == 1)
            return nums[0];

        var numberCountDictionary = new Dictionary<int, int>();
        var majorityLength = nums.Length / 2;

        foreach (var num in nums)
        {
            if (numberCountDictionary.ContainsKey(num))
            {
                numberCountDictionary[num]++;

                if (numberCountDictionary[num] > majorityLength)
                    return num;
            }
            else
                numberCountDictionary.Add(num, 1);
        }

        return 0;
    }
}