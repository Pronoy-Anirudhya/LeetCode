Console.WriteLine(new Solution().FindMin([2, 1]));
Console.ReadLine();

public class Solution
{
    public int FindMin(int[] nums)
    {
        if (nums.Length == 1)
            return nums[0];

        var left = 0;
        var right = nums.Length - 1;
        var minimumValue = int.MaxValue;

        /*
         * The idea is to figure out whether the entire range is already sorted (nums[left < nums[right]]), then just take min between nums[left] and current minimumValue.
         * Otherwise we have to determine whether to go right or left.
         * If the mid value is >= than nums[left], that means we are on the left part of the sorted array after rotation whose values will always be higher than the right part of the sorted array [left part(3,4,5) right part(1,2)].
         * If mid is < nums[left], it means we are in the right part of the sorted array and we should go left.
         * */
        while (left <= right)
        {
            //First check if it's the entire sorted range, then just return the min value between left and current min
            if (nums[left] < nums[right])
                return Math.Min(nums[left], minimumValue);

            var mid = left + ((right - left) / 2);
            minimumValue = Math.Min(nums[mid], minimumValue);

            //Go RIGHT if mid falls in the left part of sorted array, else go LEFT
            if (nums[mid] >= nums[left])
                left = ++mid;
            else
                right = --mid;
        }

        return minimumValue;
    }
}