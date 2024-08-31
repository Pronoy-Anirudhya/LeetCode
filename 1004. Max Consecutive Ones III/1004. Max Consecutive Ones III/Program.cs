Console.WriteLine(new Solution().LongestOnes([1, 1, 1, 0], 4));
Console.ReadLine();

public class Solution
{
    public int LongestOnes(int[] nums, int k)
    {
        var maxOneSequence = int.MinValue;
        var numberOfFlippedZero = 0;
        var left = 0;
        var right = 0;

        while (right < nums.Length)
        {
            if (nums[right] == 0)
                numberOfFlippedZero++;

            if (numberOfFlippedZero > k)
            {
                while (numberOfFlippedZero > k)
                {
                    if (nums[left] == 0)
                        numberOfFlippedZero--;

                    left++;
                }
            }

            var currentOneSequence = (right - left) + 1;
            maxOneSequence = Math.Max(maxOneSequence, currentOneSequence);

            right++;
        }

        return maxOneSequence;
    }
}