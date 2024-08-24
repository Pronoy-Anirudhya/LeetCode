var nums = new int[] { -1 };
Console.WriteLine(new Solution().Search(nums, 9));
Console.ReadLine();

public class Solution
{
    public int Search(int[] nums, int target)
    {
        var leftPointer = 0;
        var rightPointer = nums.Length - 1;

        while (leftPointer <= rightPointer)
        {
            var middle = leftPointer + (rightPointer - leftPointer) / 2;

            if (nums[middle] == target)
                return middle;

            if (target > nums[middle])
                leftPointer = ++middle;
            else
                rightPointer = --middle;
        }

        return -1;
    }
}