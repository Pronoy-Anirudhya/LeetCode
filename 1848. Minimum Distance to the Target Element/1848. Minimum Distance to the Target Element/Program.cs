Console.WriteLine("Hello, World!");
Console.ReadLine();

public class Solution
{
    public int GetMinDistance(int[] nums, int target, int start)
    {
        // Start from the given index and expand outwards to find the target element. The first time we encounter the target, we can return the distance from the start index since we are checking the closest elements first. We need to check both sides of the start index to ensure we find the closest target element, which is why we use two pointers (left and right) that expand outwards from the start index.
        for (int left = start, right = start; left >= 0 || right < nums.Length; left--, right++)
        {
            if (left >= 0 && nums[left] == target)
                return start - left;

            if (right < nums.Length && nums[right] == target)
                return right - start;
        }

        return -1;
    }
}