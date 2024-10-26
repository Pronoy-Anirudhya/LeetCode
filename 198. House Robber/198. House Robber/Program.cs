Console.WriteLine(new Solution().Rob([2, 7, 9, 3, 1]));
Console.ReadLine();

public class Solution
{
    public int Rob(int[] nums)
    {
        int maxAmount = int.MinValue;

        for (int index = 0; index < nums.Length; index++)
        {
            //We would keep the maximum amount in each index as we go through. This logic here means that before we get to index 2, we can not go back two steps to add it to the amount at index and check if it's greater thant the maxAmount.
            if (index >= 2)
                nums[index] += nums[index - 2];//Since we can't rob two adjacent house, so from current index, we would go back two steps and add that amount and later see if it's the maxAmount.

            maxAmount = Math.Max(maxAmount, nums[index]);
            nums[index] = maxAmount;
        }

        return maxAmount;
    }
}