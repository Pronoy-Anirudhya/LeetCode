Console.WriteLine(new Solution().KLengthApart([1, 0, 0, 1, 0, 1], 2));
Console.ReadLine();

public class Solution
{
    public bool KLengthApart(int[] nums, int k)
    {
        int lastOneIndex = -1;

        for (int index = 0; index < nums.Length; index++)
        {
            if (nums[index] == 1)
            {
                // First one found. Just record its index.
                if (lastOneIndex == -1)
                {
                    lastOneIndex = index;
                    continue; // Move to the next index. No need to check distance for the first one.
                }

                // Check the distance between the current one and the last one. If it's less than k, return false. (index - lastOneIndex - 1) is the number of zeros between two ones. We subtract 1 because we want the distance between the ones, not including the ones themselves.
                if (index - lastOneIndex - 1 < k)
                    return false;

                lastOneIndex = index;
            }
        }

        return true; // All ones are at least k places away from each other. Return true.
    }
}