Console.WriteLine(new Solution().LongestConsecutive(new int[] { 0, 0 }));
Console.ReadLine();

public class Solution
{
    private readonly HashSet<int> numSet = new HashSet<int>();

    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length <= 1)
            return nums.Length;

        var longestConsecutiveSequenceCount = 1;

        //O(n) approach:
        for (int i = 0; i < nums.Length; i++)
        {
            if (!numSet.Contains(nums[i]))
                numSet.Add(nums[i]);
        }

        foreach (int number in numSet)
        {
            //This means it is part of a sequence since this number has a left neighbor
            if (numSet.Contains(number - 1))
                continue;

            //Now the number is actually START of a sequence since it doesn't have any left neighbor. So all we have to do is now, find the consecutive right neighbors in constant time using SET
            var currentConsecutiveSequenceCount = GetLongestSequenceCount(number);
            longestConsecutiveSequenceCount = Math.Max(longestConsecutiveSequenceCount, currentConsecutiveSequenceCount);
        }

        return longestConsecutiveSequenceCount;
    }

    public int GetLongestSequenceCount(int number)
    {
        var consecutiveSequenceCount = 1;

        while (numSet.Contains(++number))
            consecutiveSequenceCount++;

        return consecutiveSequenceCount;
    }
}

//Naive O(nlogn) SORTING approach:
/*Array.Sort(nums);

for (int i = 1; i < nums.Length; i++)
{
    if (nums[i] == nums[i - 1])
        continue;

    if (nums[i] == ++nums[i - 1])
        currentConsecutiveSequenceCount++;
    else
        currentConsecutiveSequenceCount = 1;

    longestConsecutiveSequenceCount = Math.Max(longestConsecutiveSequenceCount, currentConsecutiveSequenceCount);
}*/