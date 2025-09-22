Console.WriteLine(new Solution().MaxFrequencyElements([1, 2, 2, 3, 1, 4]));
Console.ReadLine();

public class Solution
{
    public int MaxFrequencyElements(int[] nums)
    {
        int result = 0, maxFrequency = int.MinValue;
        int[] frequency = new int[101];

        foreach (int num in nums)
        {
            frequency[num]++;
            maxFrequency = Math.Max(maxFrequency, frequency[num]); // Track the maximum frequency.
        }

        for (int index = 100; index > 0; index--)
        {
            // Count how many elements have the maximum frequency and add to the result.
            if (frequency[index] == maxFrequency)
                result += maxFrequency;
        }

        return result;
    }
}