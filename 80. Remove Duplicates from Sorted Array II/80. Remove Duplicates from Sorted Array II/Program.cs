var nums = new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 }; //Result = 7
Console.WriteLine(new Solution().RemoveDuplicates(nums));
Console.ReadLine();

public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        var uniqueElementCount = 1;
        var index = 1;
        var currentNumber = nums[0];
        var currentNumberCount = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (currentNumberCount >= 2 && nums[i] == currentNumber)
                continue;

            currentNumberCount = currentNumberCount < 2 && nums[i] == currentNumber ? ++currentNumberCount : 1;
            nums[index] = nums[i];
            currentNumber = nums[i];
            index++;
            uniqueElementCount++;
        }

        return uniqueElementCount;
    }
}