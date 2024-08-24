Console.WriteLine(new Solution().TargetIndices(new int[] { 75, 99, 19, 93, 87, 68, 12, 18, 48, 83, 24, 50, 16, 53, 36, 16, 80, 68, 46, 13, 53, 100, 50, 49, 77, 52, 34, 42, 38, 98, 73, 11, 13, 61, 72, 8, 11, 67, 98, 24, 23, 71, 47, 6, 5, 7, 97, 86, 25, 82, 11, 15, 26, 97, 69, 6, 30, 77, 98, 44, 32, 39, 71, 47, 64, 78, 6, 61, 72, 75 }, 98));
Console.ReadLine();

public class Solution
{
    public IList<int> TargetIndices(int[] nums, int target)
    {
        var targetIndices = new List<int>();
        var orderedNums = nums.OrderBy(i => i).ToArray();

        var startIndex = GetStartIndexForTarget(orderedNums, target);
        var endIndex = GetEndIndexForTarget(orderedNums, target);

        if (startIndex == -1 || endIndex == -1)
            return targetIndices;

        for (int i = startIndex; i <= endIndex; i++)
            targetIndices.Add(i);

        return targetIndices;
    }

    public int GetStartIndexForTarget(int[] nums, int target)
    {
        var startIndex = -1;
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;

            if (nums[middle] == target)
            {
                startIndex = middle;
                right = --middle;
            }
            else if (nums[middle] > target)
            {
                right = --middle;
            }
            else if (nums[middle] < target)
            {
                left = ++middle;
            }
        }

        return startIndex;
    }

    public int GetEndIndexForTarget(int[] nums, int target)
    {
        var endIndex = -1;
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;

            if (nums[middle] == target)
            {
                endIndex = middle;
                left = ++middle;
            }
            else if (nums[middle] > target)
            {
                right = --middle;
            }
            else if (nums[middle] < target)
            {
                left = ++middle;
            }
        }

        return endIndex;
    }
}