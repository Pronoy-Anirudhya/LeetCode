Console.WriteLine(new Solution().MaximumSubarraySum(new int[] { 5, 3, 3, 1, 1 }, 3));
Console.ReadLine();

public class Solution
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        var maxSum = 0L;
        var currentSum = 0L;
        var left = 0;
        var right = 0;
        var numbersInSubarray = new Dictionary<int, int>();

        while (right < nums.Length)
        {
            var currentNumber = nums[right];
            currentSum += currentNumber;

            if (!numbersInSubarray.TryAdd(currentNumber, right))
            {
                var removeNumbersFromSubarrayUpto = numbersInSubarray[currentNumber];

                for (; left <= removeNumbersFromSubarrayUpto; left++)
                {
                    currentSum -= nums[left];
                    numbersInSubarray.Remove(nums[left]);
                }

                numbersInSubarray.Add(currentNumber, right);
            }

            if (numbersInSubarray.Count == k)
            {
                maxSum = Math.Max(maxSum, currentSum);
                currentSum -= nums[left];
                numbersInSubarray.Remove(nums[left]);
                left++;
            }

            right++;
        }

        return maxSum;
    }
}