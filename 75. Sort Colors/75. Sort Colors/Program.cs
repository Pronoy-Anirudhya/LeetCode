new Solution().SortColors(new int[] { 2, 0, 2, 1, 1, 0 });
Console.ReadLine();

public class Solution
{
    public void SortColors(int[] nums)
    {
		/*
         * Dutch National Flag Algorithm
         * - Keep all the 0's on the left side of left
         * - Keep all the 1's on the right side of right
         * - If middle = 0
         *      swap(left, middle) -> then left++ & middle
         * - If middle = 1
         *      increment middle
         * - If middle = 1
         *      swap(right, middle) -> then right--
         *  - Do it until middle crosees right (middle <= right).
         */

        var left = 0;
        var right = nums.Length - 1;
        var middle = 0;

        while (middle <= right)
        {
            if (nums[middle] == 0)
            {
                (nums[left], nums[middle]) = (nums[middle], nums[left]);
                left++;
                middle++;
            }
            else if (nums[middle] == 1)
            {
                middle++;
            }
            else if (nums[middle] == 2)
            {
                (nums[right], nums[middle]) = (nums[middle], nums[right]);
                right--;
            }
        }
		
        /*var redCount = 0; //0
        var whiteCount = 0; //1
        var blueCount = 0; //2

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                redCount++;
            else if (nums[i] == 1)
                whiteCount++;
            else if (nums[i] == 2)
                blueCount++;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (redCount > 0)
            {
                nums[i] = 0;
                redCount--;
            }
            else if (whiteCount > 0)
            {
                nums[i] = 1;
                whiteCount--;
            }
            else if (blueCount > 0)
            {
                nums[i] = 2;
                blueCount--;
            }
        }*/
    }
}