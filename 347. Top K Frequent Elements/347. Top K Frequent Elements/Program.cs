Console.WriteLine(new Solution().TopKFrequent([4, 2, 2, 2, 3, 3, 1], 2));
Console.ReadLine();

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var numberFrequency = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (numberFrequency.ContainsKey(nums[i]))
                numberFrequency[nums[i]]++;
            else
                numberFrequency[nums[i]] = 1;
        }

        var frequentElements = numberFrequency.OrderByDescending(item => item.Value)
                                              .Select(item => item.Key)
                                              .Take(k)
                                              .ToArray();

        return frequentElements;
    }
}